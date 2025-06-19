using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Entities
{
    public class Menu: BaseEntity
    {
        public string Name { get; set; }

        public int RestaurantId { get; set; }
        [ForeignKey("RestaurantId")]
        public virtual Restaurant Restaurant { get; set; }

        public virtual List<Product> Products { get; set; } = new List<Product>();
    }
}
