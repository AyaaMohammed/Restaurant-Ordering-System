using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTOs
{
    public class RestDataDTO
    {
        public int NumberOfRestaurants { get; set; }
        public int NumberOfCustomers { get; set; }
        public int NumberOfFavorites { get; set; }
        public int NumberOfRegularCustomers { get; set; }
    }
}
