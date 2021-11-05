using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class ProductAccessory
    {
        public int Id { get; set; }
        public int AccessoryId { get; set; }
        public int ProductId { get; set; }
        public Accessory Editions { get; set; }
        public Product Products { get; set; }
    }
}
