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
    public class AssignRoutesController : ControllerBase
    {
        private readonly TrackingDbContext _context;
        private readonly IAssignRouteService _service;
        public AssignRoutesController(TrackingDbContext context, IAssignRouteService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/AssignRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignRoute>>> GetAll()
        {
            return await _context.AssignRoute.ToListAsync();
        }

        // GET: api/AssignRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AssignRoute>> GetAssignRoute(int id)
        {
            var assignRoute = await _context.AssignRoute.FindAsync(id);

            if (assignRoute == null)
            {
                return NotFound();
            }

            return assignRoute;
        }

        // PUT: api/AssignRoutes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignRoute(int id, AssignRouteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int changed = await _service.Update(id, request);
            try
            {
                if (changed == -1)
                    return NotFound("AssignedRoute with id = " + id + " is not exist!");
                if (changed == 0)
                    return BadRequest("Update Failed!");
                var aRoute = await _context.AssignRoute.FindAsync(id);
                if (aRoute == null)
                {
                    return NotFound();
                }
                return Ok(aRoute);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AssignRouteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/AssignRoutes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssignRoute>> PostAssignRoute(AssignRouteRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = await _service.Create(request);
            if (id <= 0)
                return BadRequest("Create Failed!");
            var aRoute = await _context.AssignRoute.FindAsync(id);

            return CreatedAtAction("GetAssignRoute", new { id = aRoute.Id }, aRoute);
        }

        // DELETE: api/AssignRoutes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAssignRoute(int id)
        {
            var assignRoute = await _context.AssignRoute.FindAsync(id);
            if (assignRoute == null)
            {
                return NotFound();
            }

            _context.AssignRoute.Remove(assignRoute);
            int changed = await _context.SaveChangesAsync();
            if (changed > 1)
                return Ok("Deleted " + changed + " items");
            else if (changed > 0)
                return Ok("Deleted " + changed + " item");
            else
                return BadRequest();
        }

        private bool AssignRouteExists(int id)
        {
            return _context.AssignRoute.Any(e => e.Id == id);
        }
    }
}
