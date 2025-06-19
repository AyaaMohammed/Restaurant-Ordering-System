using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Core.DTOs;
using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Repository.Repository;

namespace Restaurant.APIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly ILogger<RestaurantController> _logger;
        private readonly IUnitOfWork _unitOfWork;
        public IMapper _map { get; }
        public RestaurantController(ILogger<RestaurantController> logger, IUnitOfWork unitOfWork,IMapper mapper)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
            _map = mapper;
            if (_unitOfWork?.RestaurantRepository != null)
            {
                var typeName = _unitOfWork.RestaurantRepository.GetType().FullName;
                _logger.LogInformation("RestaurantRepository Type: {TypeName}", typeName);
            }
            else
            {
                _logger.LogWarning("RestaurantRepository is null in UnitOfWork.");
            }
        }
        [HttpGet]
        public IActionResult GetAllRestaurants()
        {
            var restaurants = _unitOfWork.Restaurants.GetAll();
            if (restaurants == null || !restaurants.Any())
            {
                return NotFound("No restaurants found.");
            }

            var restaurantDTOs = _map.Map<List<RestaurantDTO>>(restaurants);
            return Ok(restaurantDTOs);
        }
        [HttpGet("paginated")]
        public async Task<IActionResult> GetRestaurantsPaginated(int page = 1, int pageSize = 3)
        {
            var restaurants = await _unitOfWork.RestaurantRepository.GetPagination(page, pageSize);
            if (restaurants == null || !restaurants.Any())
            {
                return NotFound("No restaurants found.");
            }

            var restaurantDTOs = _map.Map<List<RestaurantDTO>>(restaurants);
            return Ok(restaurantDTOs);
        }
        [HttpGet("summary")]
        public IActionResult GetRestaurantDataSummary()
        {
            var restaurants = _unitOfWork.Restaurants.GetAll().ToList();
            var customers = _unitOfWork.Customers.GetAll().ToList();
            if (restaurants == null || customers == null)
            {
                return NotFound("No data found.");
            }

            var numberOfRestaurants = restaurants?.Count ?? 0;
            var numberOfCustomers = customers?.Count ?? 0;

            var numberOfFavorites = restaurants?.Sum(r => r.CustomerRestaurants.Count()) ?? 0;
            var numberOfRegularCustomers = customers?.Count(c => c.Orders != null && c.Orders.Count > 1) ?? 0;

            var data = new RestDataDTO
            {
                NumberOfRestaurants = numberOfRestaurants,
                NumberOfCustomers = numberOfCustomers,
                NumberOfFavorites = numberOfFavorites,
                NumberOfRegularCustomers = numberOfRegularCustomers
            };

            return Ok(data);
        }
        [HttpGet("search")]
        public IActionResult SearchRestaurants(string RestaurantName = null, string City = null)
        {
            var restaurants = _unitOfWork.Restaurants.GetAll();
            if (restaurants == null || !restaurants.Any())
            {
                return NotFound("No restaurants found.");
            }

            var filteredRestaurants = restaurants.Where(r =>
                (string.IsNullOrEmpty(RestaurantName) || r.Name.Contains(RestaurantName)) &&
                (string.IsNullOrEmpty(City) || r.City.Contains(City))
            ).ToList();
            if (filteredRestaurants == null || !filteredRestaurants.Any())
            {
                return NotFound("No restaurants found.");
            }
            var restaurantDTOs = _map.Map<List<RestaurantDTO>>(filteredRestaurants);
            return Ok(restaurantDTOs);
        }
        [HttpGet("Address")]
        public IActionResult GetRestaurantAddress(int restaurantId)
        {
            var restaurant = _unitOfWork.Restaurants.GetById(restaurantId);
            if (restaurant == null)
            {
                return NotFound("Restaurant not found.");
            }

            var AddDTO = _map.Map<AddressDTO>(restaurant);  
            return Ok(AddDTO);
        }

    }
}
