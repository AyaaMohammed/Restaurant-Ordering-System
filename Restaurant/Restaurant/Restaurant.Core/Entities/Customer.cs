using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Entities
{
    public class Customer: BaseEntity
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string Phone { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(50)]
        public string Governorate { get; set; }

        [StringLength(100)]
        public string Street { get; set; }

        [Required]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+{}\[\]:;<>,.?~\/\-]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters long, contain at least one uppercase letter, one lowercase letter, one number, and one special character.")]
        public string Password { get; set; }

        [StringLength(2000)]
        public string? RefreshToken { get; set; }

        public DateTime? RefreshTokenExpiryTime { get; set; }

        [StringLength(100)]
        public string? PasswordResetToken { get; set; }

        public DateTime? PasswordResetTokenExpiry { get; set; }

        public virtual List<CustomerRestaurant> CustomerRestaurants { get; set; }

        public virtual List<Order> Orders { get; set; } = new List<Order>();

        public virtual List<Review> Reviews { get; set; } = new List<Review>();
    }
    
    
}
