using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTOs.Account
{
    public class RegisterDTO
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        [MinLength(20, ErrorMessage = "Address must be at least 20 characters.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Phone is required.")]
        [MinLength(11, ErrorMessage = "Phone must be at least 11 characters.")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required.")]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\/-]).{8,}$",
            ErrorMessage = "Password must be at least 8 characters long, include uppercase, lowercase, number, and special character.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required.")]
        [Compare("Password", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

    }
}
