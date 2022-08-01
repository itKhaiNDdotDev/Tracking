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
    public class TreasurersController : ControllerBase
    {
        private readonly TrackingDbContext _context;

        public TreasurersController(TrackingDbContext context)
        {
            _context = context;
        }

        // GET: api/Treasurers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Treasurer>>> GetTreasurer()
        {
            return await _context.Treasurer.ToListAsync();
        }

        // GET: api/Treasurers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Treasurer>> GetTreasurer(int id)
        {
            var treasurer = await _context.Treasurer.FindAsync(id);

            if (treasurer == null)
            {
                return NotFound();
            }

            return treasurer;
        }

        // PUT: api/Treasurers/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTreasurer(int id, Treasurer treasurer)
        {
            if (id != treasurer.Id)
            {
                return BadRequest();
            }

            _context.Entry(treasurer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TreasurerExists(id))
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

        // POST: api/Treasurers
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Treasurer>> PostTreasurer(Treasurer treasurer)
        {
            _context.Treasurer.Add(treasurer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTreasurer", new { id = treasurer.Id }, treasurer);
        }

        // DELETE: api/Treasurers/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Treasurer>> DeleteTreasurer(int id)
        {
            var treasurer = await _context.Treasurer.FindAsync(id);
            if (treasurer == null)
            {
                return NotFound();
            }

            _context.Treasurer.Remove(treasurer);
            await _context.SaveChangesAsync();

            return treasurer;
        }

        private bool TreasurerExists(int id)
        {
            return _context.Treasurer.Any(e => e.Id == id);
        }
    }
}
