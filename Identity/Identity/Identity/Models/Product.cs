using Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Models
{
    public class Product
    {
        public Product()
        {
            this.Accessories = new HashSet<Accessory>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string Description { get; set; }
        // TODO: Skal laves om sådan den kan være null
        public string AccessoriesAdded { get; set; }
        public int AccesoryId { get; set; }
        public virtual ICollection<Accessory> Accessories { get; set; }

        /*
        private readonly WebshopContext _context;

        public Product(WebshopContext context)
        {
            _context = context;
        }
        public Product(string _AccessoriesAdded)
        {
            AccessoriesAdded = _AccessoriesAdded;
            string[] number = AccessoriesAdded.Split(',');
            List<Accessory> _Accessory = new List<Accessory>();

            foreach (var word in number)
            {
                int i = Int32.Parse(word);
                Console.WriteLine(word);
                var temp = GetAccessory(i);
                //_Accessory.Add(temp);
            }


        }

        
        public async Task<IActionResult> GetAccessory(int id)
        {
            var accessory = await _context.Accessories.FindAsync(id);

            if (accessory == null)
            {
                return null;
            }

            return accessory;
        }*/
    }
}
