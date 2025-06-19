using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repository.Repository
{
    public class CustomerRepository : GenericRepository<Restaurant.Core.Entities.Customer>, ICustomerRepository
    {
        private readonly RestaurantContext _context;

        public CustomerRepository(RestaurantContext context) : base(context)
        {
            _context = context;
        }
        public Customer GetByEmail(string email)
        {
            return _context.Customers.FirstOrDefault(c => c.Email == email);
        }
        public Customer CheckLogin(string email, string password)
        {
            return _context.Customers
                .FirstOrDefault(c => c.Email == email && c.Password == password);
        }
        public Customer GetByRefreshToken(string refreshToken)
        {
            return _context.Customers
                .FirstOrDefault(c => c.RefreshToken == refreshToken && c.RefreshTokenExpiryTime > DateTime.UtcNow);
        }
    }
}
