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
    public class WarrningStaffsController : ControllerBase
    {
        private readonly TrackingDbContext _context;

        public WarrningStaffsController(TrackingDbContext context)
        {
            _context = context;
        }

        // GET: api/WarrningStaffs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarrningStaff>>> GetAll()
        {
            return await _context.WarrningStaff.ToListAsync();
        }

        // GET: api/WarrningStaffs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarrningStaff>> GetWarrningStaff(int id)
        {
            var warrningStaff = await _context.WarrningStaff.FindAsync(id);

            if (warrningStaff == null)
            {
                return NotFound();
            }

            return warrningStaff;
        }

        // PUT: api/WarrningStaffs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarrningStaff(int id, WarrningStaff warrningStaff)
        {
            if (id != warrningStaff.Id)
            {
                return BadRequest();
            }

            _context.Entry(warrningStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarrningStaffExists(id))
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

        // POST: api/WarrningStaffs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WarrningStaff>> PostWarrningStaff(WarrningStaff warrningStaff)
        {
            _context.WarrningStaff.Add(warrningStaff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarrningStaff", new { id = warrningStaff.Id }, warrningStaff);
        }

        // DELETE: api/WarrningStaffs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WarrningStaff>> DeleteWarrningStaff(int id)
        {
            var warrningStaff = await _context.WarrningStaff.FindAsync(id);
            if (warrningStaff == null)
            {
                return NotFound();
            }

            _context.WarrningStaff.Remove(warrningStaff);
            await _context.SaveChangesAsync();

            return warrningStaff;
        }

        // PATCH: api/WarningStaff/5/RemoveRfid
        [HttpPatch("{id}/remove-rfid")]
        public async Task<IActionResult> RemoveRfid(int id)
        {
            var staff = await _context.WarrningStaff.FindAsync(id);
            if (staff == null)
                return NotFound();
            staff.RfidId = null;
            var changed = await _context.SaveChangesAsync();

            try
            {
                //await _context.SaveChangesAsync();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                if (changed <= 0)
                    return BadRequest();
                return Ok("Remove RFID success!");
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarrningStaffExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        private bool WarrningStaffExists(int id)
        {
            return _context.WarrningStaff.Any(e => e.Id == id);
        }
    }
}
