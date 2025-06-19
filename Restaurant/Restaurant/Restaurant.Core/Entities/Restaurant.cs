using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Entities
{
    public class Restaurant:BaseEntity
    {
        [StringLength(30)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5.")]
        public int Rate { get; set; }
        public string? Image { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Governorate { get; set; } 

        [StringLength(100)]
        public string Street { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public virtual List<CustomerRestaurant> CustomerRestaurants { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();
        public virtual List<Review> Reviews { get; set; } = new List<Review>();

        public virtual List<Menu> Menus { get; set; } = new List<Menu>();
    }
}
