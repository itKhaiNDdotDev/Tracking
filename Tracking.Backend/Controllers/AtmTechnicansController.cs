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
    public class AtmTechnicansController : ControllerBase
    {
        private readonly TrackingDbContext _context;
        private readonly IAtmTechnicanService _service; 
        public AtmTechnicansController(TrackingDbContext context, IAtmTechnicanService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/AtmTechnicans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AtmTechnican>>> GetAll()
        {
            return await _context.AtmTechnican.ToListAsync();
        }

        // GET: api/AtmTechnicans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AtmTechnican>> GetAtmTechnican(int id)
        {
            var atmTechnican = await _context.AtmTechnican.FindAsync(id);

            if (atmTechnican == null)
            {
                return NotFound();
            }

            return atmTechnican;
        }

        // PUT: api/AtmTechnicans/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, AtmTechnicanRequest request)
        {
            //_context.Entry(atmTechnican).State = EntityState.Modified;
            try
            {
                //await _context.SaveChangesAsync();
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                int changed = await _service.Update(id, request);
                if(changed == -1)
                    return NotFound("AtmTechnican with id = " + id + " is not exist!");
                if (changed == 0)
                    return BadRequest("Update Failed!");
                var atmTechnican = await _context.AtmTechnican.FindAsync(id);
                if (atmTechnican == null)
                {
                    return NotFound();
                }
                return Ok(atmTechnican);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AtmTechnicanExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/AtmTechnicans
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AtmTechnican>> Create(AtmTechnicanRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = await _service.Create(request);
            if (id <= 0)
                return BadRequest("Create Failed!");
            var atmTechnican = await _context.AtmTechnican.FindAsync(id);

            return CreatedAtAction("GetAtmTechnican", new { id = atmTechnican.Id }, atmTechnican);
        }

        // DELETE: api/AtmTechnicans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult/*<AtmTechnican>*/> DeleteAtmTechnican(int id)
        {
            var atmTechnican = await _context.AtmTechnican.FindAsync(id);
            if (atmTechnican == null)
            {
                return NotFound();
            }

            _context.AtmTechnican.Remove(atmTechnican);
            int changed = await _context.SaveChangesAsync();
            if (changed > 1)
                return Ok("Deleted " + changed + " items");
            else if (changed > 0)
                return Ok("Deleted " + changed + " item");
            else
                return BadRequest();
        }

        private bool AtmTechnicanExists(int id)
        {
            return _context.AtmTechnican.Any(e => e.Id == id);
        }
    }
}
