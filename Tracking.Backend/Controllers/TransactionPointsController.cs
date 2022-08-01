using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracking.Backend.Data;
using Tracking.Backend.Models;

namespace Tracking.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionPointsController : ControllerBase
    {
        private readonly TrackingDbContext _context;

        public TransactionPointsController(TrackingDbContext context)
        {
            _context = context;
        }

        // GET: api/TransactionPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionPoint>>> GetTransactionPoint()
        {
            return await _context.TransactionPoint.ToListAsync();
        }

        // GET: api/TransactionPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionPoint>> GetTransactionPoint(int id)
        {
            var transactionPoint = await _context.TransactionPoint.FindAsync(id);

            if (transactionPoint == null)
            {
                return NotFound();
            }

            return transactionPoint;
        }

        // PUT: api/TransactionPoints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionPoint(int id, TransactionPoint transactionPoint)
        {
            if (id != transactionPoint.Id)
            {
                return BadRequest();
            }

            _context.Entry(transactionPoint).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionPointExists(id))
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

        // POST: api/TransactionPoints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransactionPoint>> PostTransactionPoint(TransactionPoint transactionPoint)
        {
            _context.TransactionPoint.Add(transactionPoint);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTransactionPoint", new { id = transactionPoint.Id }, transactionPoint);
        }

        // DELETE: api/TransactionPoints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransactionPoint>> DeleteTransactionPoint(int id)
        {
            var transactionPoint = await _context.TransactionPoint.FindAsync(id);
            if (transactionPoint == null)
            {
                return NotFound();
            }

            _context.TransactionPoint.Remove(transactionPoint);
            await _context.SaveChangesAsync();

            return transactionPoint;
        }

        private bool TransactionPointExists(int id)
        {
            return _context.TransactionPoint.Any(e => e.Id == id);
        }
    }
}
