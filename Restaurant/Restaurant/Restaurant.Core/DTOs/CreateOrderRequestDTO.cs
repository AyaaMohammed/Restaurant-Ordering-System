using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.DTOs
{
    public  class CreateOrderRequestDTO
    {
        public CustomerDataDTO CustomerData { get; set; }
        public int RestaurantId { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}
