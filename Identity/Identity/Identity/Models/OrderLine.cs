using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class OrderLine
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public string AccessoriesAdded { get; set; }
        public int ProductId { get; set; }
        public List<Accessory> Accessory { get; set; }
        public Product Product { get; set; }
        // TODO: tror ikke Accessory er nødvendig her men det kan den være at den bliver, så jeg lader den stå til at blive fikset senere hvis jeg har ret
    }
}
