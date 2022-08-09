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
    public class WarningLogsController : ControllerBase
    {
        private readonly TrackingDbContext _context;

        public WarningLogsController(TrackingDbContext context)
        {
            _context = context;
        }

        // GET: api/WarningLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarningLog>>> GetWarningLog()
        {
            return await _context.WarningLog.ToListAsync();
        }

        // GET: api/WarningLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<WarningLog>> GetWarningLog(int id)
        {
            var warningLog = await _context.WarningLog.FindAsync(id);

            if (warningLog == null)
            {
                return NotFound();
            }

            return warningLog;
        }

        // PUT: api/WarningLogs/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWarningLog(int id, WarningLog warningLog)
        {
            if (id != warningLog.Id)
            {
                return BadRequest();
            }

            _context.Entry(warningLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WarningLogExists(id))
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

        // POST: api/WarningLogs
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<WarningLog>> PostWarningLog(WarningLog warningLog)
        {
            _context.WarningLog.Add(warningLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetWarningLog", new { id = warningLog.Id }, warningLog);
        }

        // DELETE: api/WarningLogs/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<WarningLog>> DeleteWarningLog(int id)
        {
            var warningLog = await _context.WarningLog.FindAsync(id);
            if (warningLog == null)
            {
                return NotFound();
            }

            _context.WarningLog.Remove(warningLog);
            await _context.SaveChangesAsync();

            return warningLog;
        }

        private bool WarningLogExists(int id)
        {
            return _context.WarningLog.Any(e => e.Id == id);
        }
    }
}
