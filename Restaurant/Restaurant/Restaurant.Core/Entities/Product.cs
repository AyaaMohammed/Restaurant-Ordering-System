using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Core.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }        
        public string? ImageUrl { get; set; }

        public virtual List<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public int MenuId { get; set; }

        [ForeignKey("MenuId")]  
        public virtual Menu Menu { get; set; }
    }
}
