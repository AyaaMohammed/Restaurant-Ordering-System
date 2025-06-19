using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Restaurant.Core.DTOs;
using Restaurant.Core.Interfaces;
using Restaurant.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ILogger<OrderController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IEmailService _emailService;
        private readonly IMapper _map;

        public OrderController(
            ILogger<OrderController> logger,
            IUnitOfWork unitOfWork,
            IMapper map,
            IEmailService emailService)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _map = map;
            _emailService = emailService;
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDTO request)
        {
            if (!IsOrderDataValid(request.CustomerData, request.OrderItems))
                return BadRequest("Invalid order data.");

            var customer = GetOrCreateCustomer(request.CustomerData);
            if (customer == null)
                return BadRequest("Failed to create or get customer.");

            var restaurant = _unitOfWork.Restaurants.GetById(request.RestaurantId);
            if (restaurant == null)
                return NotFound("Restaurant not found.");

            var order = CreateOrderEntity(customer.Id, restaurant.Id);
            try
            {
                AddOrderItems(order, request.OrderItems);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error adding order items.");
                return BadRequest("Failed to add order items.");
            }


            try
            {
                string emailBody = GenerateEmailBody(order, request.OrderItems);
                await _emailService.SendEmailAsync(customer.Email, "Your Order Confirmation", emailBody);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to send confirmation email.");
            }

            return Ok(new { message = "Order created successfully." });
        }

        private bool IsOrderDataValid(CustomerDataDTO customerData, List<OrderItemDTO> orderItems)
        {
            return customerData != null && orderItems != null && orderItems.Count > 0;
        }

        private Restaurant.Core.Entities.Customer GetOrCreateCustomer(CustomerDataDTO customerData)
        {
            var customer = _unitOfWork.Customers.GetAll().FirstOrDefault(c => c.Email == customerData.Email);
            if (customer == null)
            {
                customer = _map.Map<Restaurant.Core.Entities.Customer>(customerData);
                _unitOfWork.Customers.Add(customer);
                _unitOfWork.Save();
            }
            return customer;
        }

        private Restaurant.Core.Entities.Order CreateOrderEntity(int customerId, int restaurantId)
        {
            var order = new Restaurant.Core.Entities.Order
            {
                OrderDate = DateTime.Now,
                Status = Restaurant.Core.Enums.OrderStatus.Completed,
                CustomerId = customerId,
                RestaurantId = restaurantId,
            };
            _unitOfWork.Orders.Add(order);
            _unitOfWork.Save();
            return order;
        }

        private void AddOrderItems(Restaurant.Core.Entities.Order order, List<OrderItemDTO> orderItems)
        {
            foreach (var item in orderItems)
            {
                var product = _unitOfWork.Products.GetById(item.ProductId);
                if (product == null)
                    throw new Exception($"Product with ID {item.ProductId} not found.");

                var orderItem = new Restaurant.Core.Entities.OrderItem
                {
                    ProductId = product.Id,
                    Quantity = item.Quantity,
                    OrderId = order.Id
                };
                _unitOfWork.OrderItems.Add(orderItem);
            }
            _unitOfWork.Save();
        }

        private string GenerateEmailBody(Restaurant.Core.Entities.Order order, List<OrderItemDTO> items)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"<h2>Thanks for your order!</h2>");
            sb.AppendLine($"<p>Order Date: {order.OrderDate}</p><ul>");
            decimal total = 0;

            foreach (var item in items)
            {
                var product = _unitOfWork.Products.GetById(item.ProductId);
                decimal itemTotal = product.Price * item.Quantity;
                total += itemTotal;
                sb.AppendLine($"<li>{product.Name} x {item.Quantity} = {itemTotal:C}</li>");
            }

            sb.AppendLine("</ul>");
            sb.AppendLine($"<strong>Total: {total:C}</strong>");
            return sb.ToString();
        }
    }
}

