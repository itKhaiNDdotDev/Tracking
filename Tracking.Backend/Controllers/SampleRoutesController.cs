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
    public class SampleRoutesController : ControllerBase
    {
        private readonly TrackingDbContext _context;

        public SampleRoutesController(TrackingDbContext context)
        {
            _context = context;
        }

        // GET: api/SampleRoutes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<SampleRoute>>> GetSampleRoutes()
        {
            return await _context.SampleRoutes.ToListAsync();
        }

        // GET: api/SampleRoutes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<SampleRoute>> GetSampleRoute(int id)
        {
            var sampleRoute = await _context.SampleRoutes.FindAsync(id);

            if (sampleRoute == null)
            {
                return NotFound();
            }

            return sampleRoute;
        }

        // PUT: api/SampleRoutes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSampleRoute(int id, SampleRoute sampleRoute)
        {
            if (id != sampleRoute.Id)
            {
                return BadRequest();
            }

            _context.Entry(sampleRoute).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SampleRouteExists(id))
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

        // POST: api/SampleRoutes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<SampleRoute>> PostSampleRoute(SampleRoute sampleRoute)
        {
            _context.SampleRoutes.Add(sampleRoute);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSampleRoute", new { id = sampleRoute.Id }, sampleRoute);
        }

        // DELETE: api/SampleRoutes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<SampleRoute>> DeleteSampleRoute(int id)
        {
            var sampleRoute = await _context.SampleRoutes.FindAsync(id);
            if (sampleRoute == null)
            {
                return NotFound();
            }

            _context.SampleRoutes.Remove(sampleRoute);
            await _context.SaveChangesAsync();

            return sampleRoute;
        }

        private bool SampleRouteExists(int id)
        {
            return _context.SampleRoutes.Any(e => e.Id == id);
        }
    }
}
