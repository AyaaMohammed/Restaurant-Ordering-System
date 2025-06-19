using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Entities
{
    public class CustomerRestaurant
    {
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        public  virtual Customer Customer { get; set; }
        [ForeignKey("Restaurant")]
        public int RestaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }
    }
}
