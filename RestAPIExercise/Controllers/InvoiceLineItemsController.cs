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
    public class InvoiceLineItemsController : ControllerBase
    {
        private readonly RestAPIContext _context;

        public InvoiceLineItemsController(RestAPIContext context)
        {
            _context = context;
        }

        // GET: api/InvoiceLineItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<InvoiceLineItem>>> GetInvoiceLineItems()
        {
            return await _context.InvoiceLineItems.ToListAsync();
        }

        // GET: api/InvoiceLineItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<InvoiceLineItem>> GetInvoiceLineItem(int id)
        {
            var invoiceLineItem = await _context.InvoiceLineItems.SingleOrDefaultAsync(i => i.Id == id);

            if (invoiceLineItem == null)
            {
                return NotFound();
            }

            return invoiceLineItem;
        }

        // PUT: api/InvoiceLineItems/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInvoiceLineItem(int id, InvoiceLineItem invoiceLineItem)
        {
            if (id != invoiceLineItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(invoiceLineItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InvoiceLineItemExists(id))
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

        // POST: api/InvoiceLineItems
        [HttpPost]
        public async Task<ActionResult<InvoiceLineItem>> PostInvoiceLineItem(InvoiceLineItem invoiceLineItem)
        {
            _context.InvoiceLineItems.Add(invoiceLineItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetInvoiceLineItem", new { id = invoiceLineItem.Id }, invoiceLineItem);
        }

        // DELETE: api/InvoiceLineItems/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInvoiceLineItem(int id)
        {
            var invoiceLineItem = await _context.InvoiceLineItems.FindAsync(id);
            if (invoiceLineItem == null)
            {
                return NotFound();
            }

            _context.InvoiceLineItems.Remove(invoiceLineItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool InvoiceLineItemExists(int id)
        {
            return _context.InvoiceLineItems.Any(e => e.Id == id);
        }
    }
}
