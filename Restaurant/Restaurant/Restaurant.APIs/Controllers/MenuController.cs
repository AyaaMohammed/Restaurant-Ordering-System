using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.DTOs;
using Restaurant.Core.Repositories;

namespace Restaurant.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _map { get; }
        public MenuController(ILogger<RestaurantController> logger, IUnitOfWork unitOfWork, IMapper map)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _map = map;
        }
        [HttpGet]
        public IActionResult GetSpecificMenuProducts(int restaurantId)
        {
            var menus = _unitOfWork.Menus.GetAll().Where(m => m.RestaurantId == restaurantId).ToList();

            if (menus == null || !menus.Any())
            {
                return NotFound("No menu found.");
            }

            var products = menus.SelectMany(m => m.Products).ToList(); 

            if (products == null || !products.Any())
            {
                return NotFound("No products found.");
            }
            var productDTOs = _map.Map<List<Restaurant.Core.DTOs.MenuDTO>>(products);
            return Ok(productDTOs);
        }


    }
}
