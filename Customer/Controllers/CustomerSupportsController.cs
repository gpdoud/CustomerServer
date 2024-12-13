using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Customer.Data;
using Customer.Models;

namespace Customer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerSupportsController : ControllerBase
    {
        private readonly CustomerContext _context;

        public CustomerSupportsController(CustomerContext context)
        {
            _context = context;
        }

        // GET: api/CustomerSupports
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CustomerSupport>>> GetCustomerSupport()
        {
            return await _context.CustomerSupport.ToListAsync();
        }

        // GET: api/CustomerSupports/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerSupport>> GetCustomerSupport(int id)
        {
            var customerSupport = await _context.CustomerSupport.FindAsync(id);

            if (customerSupport == null)
            {
                return NotFound();
            }

            return customerSupport;
        }

        // PUT: api/CustomerSupports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomerSupport(int id, CustomerSupport customerSupport)
        {
            if (id != customerSupport.Id)
            {
                return BadRequest();
            }

            _context.Entry(customerSupport).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerSupportExists(id))
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

        // POST: api/CustomerSupports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CustomerSupport>> PostCustomerSupport(CustomerSupport customerSupport)
        {
            _context.CustomerSupport.Add(customerSupport);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomerSupport", new { id = customerSupport.Id }, customerSupport);
        }

        // DELETE: api/CustomerSupports/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomerSupport(int id)
        {
            var customerSupport = await _context.CustomerSupport.FindAsync(id);
            if (customerSupport == null)
            {
                return NotFound();
            }

            _context.CustomerSupport.Remove(customerSupport);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerSupportExists(int id)
        {
            return _context.CustomerSupport.Any(e => e.Id == id);
        }
    }
}
