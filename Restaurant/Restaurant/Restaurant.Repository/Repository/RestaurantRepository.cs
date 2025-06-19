using Azure;
using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant.Repository.Data;
using Restaurant.Core.Entities;

namespace Restaurant.Repository.Repository
{
    public class RestaurantRepository : GenericRepository<Restaurant.Core.Entities.Restaurant>, IRestaurantRepository
    {
        private readonly RestaurantContext _context;

        public RestaurantRepository(RestaurantContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<Restaurant.Core.Entities.Restaurant>> GetPagination(int page = 1, int pageSize = 3)
        {
            var restaurants = await _context.Restaurants
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return restaurants;
        }
    }

}
