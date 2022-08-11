using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tracking.Backend.Data;
using Tracking.Backend.Models;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManageUnitsController : ControllerBase
    {
        private readonly TrackingDbContext _context;
        private readonly IManageUnitService _service;
        public ManageUnitsController(TrackingDbContext context, IManageUnitService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/ManageUnits
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManageUnit>>> GetAll()
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
        public async Task<IActionResult> PutManageUnit(int id, string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int changed = await _service.Update(id, name);
            try
            {
                if (changed == -1)
                    return NotFound("ManageUnit with id = " + id + " is not exist!");
                if (changed == 0)
                    return BadRequest("Update Failed!");
                var unit = await _context.ManageUnit.FindAsync(id);
                if (unit == null)
                {
                    return NotFound();
                }
                return Ok(unit);
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
        }

        // POST: api/ManageUnits
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ManageUnit>> PostManageUnit(string name)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = await _service.Create(name);
            if (id <= 0)
                return BadRequest("Create Failed!");
            var unit = await _context.ManageUnit.FindAsync(id);

            return CreatedAtAction("GetManageUnit", new { id = unit.Id }, unit);
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
            int changed = await _context.SaveChangesAsync();
            if (changed > 1)
                return Ok("Deleted " + changed + " items");
            else if (changed > 0)
                return Ok("Deleted " + changed + " item");
            else
                return BadRequest();
        }

        private bool ManageUnitExists(int id)
        {
            return _context.ManageUnit.Any(e => e.Id == id);
        }
    }
}
