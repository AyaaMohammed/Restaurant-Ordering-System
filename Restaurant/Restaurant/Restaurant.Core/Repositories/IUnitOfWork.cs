using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Repositories
{
    public interface IUnitOfWork  
    {
        IEntity<Restaurant.Core.Entities.Restaurant> Restaurants { get; }
        IEntity<Customer> Customers { get; }
        IEntity<Menu> Menus { get; }
        IEntity<Product> Products { get; }
        IEntity<Order> Orders { get; }
        IEntity<OrderItem> OrderItems { get; }
        IEntity<Review> Reviews { get; }
        IEntity<CustomerRestaurant> CustomerRestaurants { get; }
        IRestaurantRepository RestaurantRepository { get; }
        ICustomerRepository CustomerRepository { get; }

        void Save();
    }
}
