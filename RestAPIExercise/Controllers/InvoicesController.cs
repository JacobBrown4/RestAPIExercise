using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestAPIExercise.Models;

namespace RestAPIExercise.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class InvoicesController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public InvoicesController(RestAPIContext context)
        {
            _context = context;
        }

        // GET: api/Invoices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceListEntry>>> GetInvoices()
        {
            return await _context.Invoices
                .Select(i => new InvoiceListEntry
                {
                    Id = i.Id,
                    InvoiceDate = i.InvoiceDate,
                    Customer = i.Customer.FirstName + " " + i.Customer.LastName,
                    ShippingAddress = i.ShippingAddress.City + ", " + i.ShippingAddress.State,
                    BillingAddress = i.BillingAddress.City + ", " + i.BillingAddress.State,
                    AmountOfLineItems = i.LineItems.Count
                
                }).ToListAsync();
        }

        // GET: api/Invoices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Invoice>> GetInvoice(int id)
        {
            var invoice = await _context.Invoices
                .Include(i => i.BillingAddress)
                .Include(i => i.ShippingAddress)
                .Include(i => i.Customer)
                .Include(i => i.LineItems)
                .SingleOrDefaultAsync(i => i.Id == id);

            if (invoice == null)
            {
                return NotFound();
            }

            return invoice;
        }

        // PUT: api/Invoices/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoice(int id, Invoice invoice)
        {
            if (id != invoice.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoice).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok("Successfuly updated.");
        }

        // POST: api/Invoices
        [HttpPost]
        public async Task<ActionResult<Invoice>> PostInvoice(InvoiceCreate invoice)
        {
            var newInvoice = new Invoice
            {
                CustomerId = invoice.CustomerId,
                InvoiceDate = invoice.InvoiceDate,
                BillingAddressId = invoice.BillingAddressId,
                ShippingAddressId = invoice.ShippingAddressId
            };
            _context.Invoices.Add(newInvoice);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoice", new { id = newInvoice.Id }, newInvoice);
        }

        // DELETE: api/Invoices/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoice(int id)
        {
            var invoice = await _context.Invoices.FindAsync(id);
            if (invoice == null)
            {
                return NotFound();
            }

            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceExists(int id)
        {
            return _context.Invoices.Any(e => e.Id == id);
        }
    }
}
