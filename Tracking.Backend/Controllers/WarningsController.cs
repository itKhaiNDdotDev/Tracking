using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracking.Backend.Data;
using Tracking.Backend.DTOs;
using Tracking.Backend.Models;

namespace Tracking.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WarningsController : ControllerBase
    {
        private readonly TrackingDbContext _context;

        public WarningsController(TrackingDbContext context)
        {
            _context = context;
        }

        // GET: api/WarningLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<WarningLog>>> GetAll()
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

        //// PUT: api/WarningLogs/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to, for
        //// more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutWarningLog(int id, WarningLog warningLog)
        //{
        //    if (id != warningLog.Id)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(warningLog).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!WarningLogExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        // POST: api/WarningLogs/AssignRoutes/{AssignRouteId}/send
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost("AssignRoutes/{rid}/send")]
        public async Task<ActionResult> PostWarningLog(int rid, WarningRequest request)
        {
            WarningLog warningLog = new WarningLog()
            {
                AssignRouteId = rid,
                Type = request.Type,
                Message = request.Message,
                SendTime = DateTime.Now
            };
            _context.WarningLog.Add(warningLog);
            int changed = await _context.SaveChangesAsync();
            if (changed == 1)
                return Ok(new { LogId = warningLog.Id, WarningType = warningLog.Type, Message = warningLog.Message, SendTime = warningLog.SendTime } );
            else
                return BadRequest();
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
            int changed = await _context.SaveChangesAsync();
            if (changed > 1)
                return Ok("Deleted " + changed + " items");
            else if (changed > 0)
                return Ok("Deleted " + changed + " item");
            else
                return BadRequest();
        }

        private bool WarningLogExists(int id)
        {
            return _context.WarningLog.Any(e => e.Id == id);
        }
    }
}
