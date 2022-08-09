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
    public class AssignRoutesController : ControllerBase
    {
        private readonly TrackingDbContext _context;

        public AssignRoutesController(TrackingDbContext context)
        {
            _context = context;
        }

        // GET: api/AssignRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignRoute>>> GetAssignRoute()
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
        public async Task<IActionResult> PutAssignRoute(int id, AssignRoute assignRoute)
        {
            if (id != assignRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(assignRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return NoContent();
        }

        // POST: api/AssignRoutes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AssignRoute>> PostAssignRoute(AssignRoute assignRoute)
        {
            _context.AssignRoute.Add(assignRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAssignRoute", new { id = assignRoute.Id }, assignRoute);
        }

        // DELETE: api/AssignRoutes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AssignRoute>> DeleteAssignRoute(int id)
        {
            var assignRoute = await _context.AssignRoute.FindAsync(id);
            if (assignRoute == null)
            {
                return NotFound();
            }

            _context.AssignRoute.Remove(assignRoute);
            await _context.SaveChangesAsync();

            return assignRoute;
        }

        private bool AssignRouteExists(int id)
        {
            return _context.AssignRoute.Any(e => e.Id == id);
        }
    }
}
