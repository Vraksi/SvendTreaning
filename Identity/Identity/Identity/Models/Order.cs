using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class Order
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public DateTime Date { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public List<OrderLine> OrderLines { get; set; }
        
        public Order()
        {
            
        }
    }
}
