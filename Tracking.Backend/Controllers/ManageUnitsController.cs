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
    public class ManageUnitsController : ControllerBase
    {
        private readonly TrackingDbContext _context;

        public ManageUnitsController(TrackingDbContext context)
        {
            _context = context;
        }

        // GET: api/ManageUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageUnit>>> GetManageUnit()
        {
            return await _context.ManageUnit.ToListAsync();
        }

        // GET: api/ManageUnits/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManageUnit>> GetManageUnit(int id)
        {
            var manageUnit = await _context.ManageUnit.FindAsync(id);

            if (manageUnit == null)
            {
                return NotFound();
            }

            return manageUnit;
        }

        // PUT: api/ManageUnits/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManageUnit(int id, ManageUnit manageUnit)
        {
            if (id != manageUnit.Id)
            {
                return BadRequest();
            }

            _context.Entry(manageUnit).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManageUnitExists(id))
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

        // POST: api/ManageUnits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ManageUnit>> PostManageUnit(ManageUnit manageUnit)
        {
            _context.ManageUnit.Add(manageUnit);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetManageUnit", new { id = manageUnit.Id }, manageUnit);
        }

        // DELETE: api/ManageUnits/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ManageUnit>> DeleteManageUnit(int id)
        {
            var manageUnit = await _context.ManageUnit.FindAsync(id);
            if (manageUnit == null)
            {
                return NotFound();
            }

            _context.ManageUnit.Remove(manageUnit);
            await _context.SaveChangesAsync();

            return manageUnit;
        }

        private bool ManageUnitExists(int id)
        {
            return _context.ManageUnit.Any(e => e.Id == id);
        }
    }
}
