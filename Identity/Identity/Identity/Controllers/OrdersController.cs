﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Identity.Data;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;

namespace Identity.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly WebshopContext _context;

        public OrdersController(WebshopContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        {
            return await _context.Orders
                .Include(s => s.Status)
                .Include(s => s.OrderLines)
                .ToListAsync();
        }

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrder(int id)
        {
            List<OrderLine> orderline = new List<OrderLine>();
            List<Accessory> listacces = new List<Accessory>();
            string stringarray;

            List<Order> order = await _context.Orders
                //.Where(s => s.CustomerId == id)
                .Include(s => s.Status)
                .Include(s => s.OrderLines)                
                .Where(s => s.CustomerId == id)
                .ToListAsync();

            var temp = order.Select(c => c.OrderLines);

            foreach (var os in temp)
            {
                os.Select(s => stringarray = s.AccessoriesAdded);
                Console.WriteLine(os.Select(s => stringarray = s.AccessoriesAdded));
            }
            
            /*
            string s = "1,2,3,2,2,4";
            string[] os = s.Split(',');
            foreach (var temp in os)
            {
                int number = Convert.ToInt32(temp);
                Accessory aess = await _context.Accessories.FindAsync(number);
                listacces.Add(aess);
                Console.WriteLine(aess.Name);
            }
            */
            
            //TODO: skal testes
            
            

            if (order == null)
            {
                return NotFound();
            }

            return order;
        }

        // PUT: api/Orders/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutOrder(int id, Order order)
        {
            if (id != order.Id)
            {
                return BadRequest();
            }

            _context.Entry(order).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrderExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Orders
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Order>> PostOrder(Order order)
        {
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetOrder", new { id = order.Id }, order);
        }

        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.Id == id);
        }
    }
}
