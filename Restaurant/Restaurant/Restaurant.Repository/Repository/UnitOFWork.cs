using Restaurant.Core.Entities;
using Restaurant.Core.Repositories;
using Restaurant.Repository.Data;
using System.Threading.Tasks;

namespace Restaurant.Repository.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RestaurantContext _db;

        private IEntity<Restaurant.Core.Entities.Restaurant> _restaurants;
        private IEntity<Customer> _customers;
        private IEntity<Menu> _menus;
        private IEntity<Product> _products;
        private IEntity<Order> _orders;
        private IEntity<OrderItem> _orderItems;
        private IEntity<Review> _reviews;
        private IEntity<CustomerRestaurant> _customerRestaurants;
        private IRestaurantRepository _restaurantRepository;
        private ICustomerRepository _customerRepository;

        public UnitOfWork(RestaurantContext db)
        {
            _db = db;
        }
        public IRestaurantRepository RestaurantRepository
        {
            get
            {
                if (_restaurantRepository == null)
                    _restaurantRepository = new RestaurantRepository(_db);
                return _restaurantRepository;
            }
        }
        public ICustomerRepository CustomerRepository
        {
            get
            {
                if(_customerRepository == null )
                    _customerRepository = new CustomerRepository(_db);
                return _customerRepository;
            }
        }
        public IEntity<Restaurant.Core.Entities.Restaurant> Restaurants
        {
            get
            {
                if (_restaurants == null)
                    _restaurants = new GenericRepository<Restaurant.Core.Entities.Restaurant>(_db);
                return _restaurants;
            }
        }

        public IEntity<Customer> Customers
        {
            get
            {
                if (_customers == null)
                    _customers = new GenericRepository<Customer>(_db);
                return _customers;
            }
        }

        public IEntity<Menu> Menus
        {
            get
            {
                if (_menus == null)
                    _menus = new GenericRepository<Menu>(_db);
                return _menus;
            }
        }

        public IEntity<Product> Products
        {
            get
            {
                if (_products == null)
                    _products = new GenericRepository<Product>(_db);
                return _products;
            }
        }

        public IEntity<Order> Orders
        {
            get
            {
                if (_orders == null)
                    _orders = new GenericRepository<Order>(_db);
                return _orders;
            }
        }

        public IEntity<OrderItem> OrderItems
        {
            get
            {
                if (_orderItems == null)
                    _orderItems = new GenericRepository<OrderItem>(_db);
                return _orderItems;
            }
        }

        public IEntity<Review> Reviews
        {
            get
            {
                if (_reviews == null)
                    _reviews = new GenericRepository<Review>(_db);
                return _reviews;
            }
        }

        public IEntity<CustomerRestaurant> CustomerRestaurants
        {
            get
            {
                if (_customerRestaurants == null)
                    _customerRestaurants = new GenericRepository<CustomerRestaurant>(_db);
                return _customerRestaurants;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
