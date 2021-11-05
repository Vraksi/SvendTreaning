using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class Accessory
    {

        public Accessory()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int PriceOfItem { get; set; }
        public string Category { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
