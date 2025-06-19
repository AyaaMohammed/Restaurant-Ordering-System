using Microsoft.EntityFrameworkCore;
using Restaurant.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Repository.Data
{
    public class RestaurantContext:DbContext
    {
        public DbSet<CustomerRestaurant> CustomerRestaurants { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<Restaurant.Core.Entities.Restaurant> Restaurants { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public RestaurantContext(DbContextOptions<RestaurantContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Favourite relationship
            modelBuilder.Entity<CustomerRestaurant>()
                .HasKey(f => new { f.CustomerId, f.RestaurantId });

            // Order-Item relationship
            modelBuilder.Entity<OrderItem>()
                .HasKey(oi => new { oi.OrderId, oi.ProductId });

        }
    }
}
