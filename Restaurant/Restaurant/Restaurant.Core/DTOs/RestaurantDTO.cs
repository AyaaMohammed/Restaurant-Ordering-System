using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTOs
{
    public class RestaurantDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Image { get; set; }

        public int Rate { get; set; }
        public string Description { get; set; }

        public int NumberOfFavorites { get; set; }
        public int NumberOfReviews { get; set; }
    }
}
