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
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RfidsController : ControllerBase
    {
        private readonly TrackingDbContext _context;
        private readonly IRfidService _service;
        public RfidsController(TrackingDbContext context,IRfidService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Rfids
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rfid>>> GetAll()
        {
            return await _context.Rfid.ToListAsync();
        }

        // GET: api/Rfids/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rfid>> GetRfid(int id)
        {
            var rfid = await _context.Rfid.FindAsync(id);

            if (rfid == null)
            {
                return NotFound();
            }

            return rfid;
        }

        // PUT: api/Rfids/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRfid(int id, RfidRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int changed = await _service.Update(id, request);
            try
            {
                if (changed == -1)
                    return NotFound("Rfid with id = " + id + " is not exist!");
                if (changed == 0)
                    return BadRequest("Update Failed!");
                var rfid = await _context.Rfid.FindAsync(id);
                if (rfid == null)
                {
                    return NotFound();
                }
                return Ok(rfid);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RfidExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Rfids
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Rfid>> PostRfid(RfidRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = await _service.Create(request);
            if (id <= 0)
                return BadRequest("Create Failed!");
            var rfid = await _context.Rfid.FindAsync(id);

            return CreatedAtAction("GetRfid", new { id = rfid.Id }, rfid);
        }

        // DELETE: api/Rfids/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Rfid>> DeleteRfid(int id)
        {
            var rfid = await _context.Rfid.FindAsync(id);
            if (rfid == null)
            {
                return NotFound();
            }

            _context.Rfid.Remove(rfid);
            int changed = await _context.SaveChangesAsync();
            if (changed > 1)
                return Ok("Deleted " + changed + " items");
            else if (changed > 0)
                return Ok("Deleted " + changed + " item");
            else
                return BadRequest();
        }

        private bool RfidExists(int id)
        {
            return _context.Rfid.Any(e => e.Id == id);
        }
    }
}
