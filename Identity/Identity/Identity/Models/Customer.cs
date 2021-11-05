using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string LoginId { get; set; }
        public List<Order> Orders { get; set; }
       
    }
}
