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
    public class TransactionPointsController : ControllerBase
    {
        private readonly TrackingDbContext _context;
        private readonly ITransactionPointService _service;
        public TransactionPointsController(TrackingDbContext context, ITransactionPointService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/TransactionPoints
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionPoint>>> GetAll()
        {
            return await _context.TransactionPoint.ToListAsync();
        }

        // GET: api/TransactionPoints/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionPoint>> GetTransactionPoint(int id)
        {
            var transactionPoint = await _context.TransactionPoint.FindAsync(id);

            if (transactionPoint == null)
            {
                return NotFound();
            }

            return transactionPoint;
        }

        // PUT: api/TransactionPoints/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionPoint(int id, TransactionPointRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int changed = await _service.Update(id, request);
            try
            {
                if (changed == -1)
                    return NotFound("TransactionPoint with id = " + id + " is not exist!");
                if (changed == 0)
                    return BadRequest("Update Failed!");
                var pt = await _context.TransactionPoint.FindAsync(id);
                if (pt == null)
                {
                    return NotFound();
                }
                return Ok(pt);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionPointExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/TransactionPoints
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<TransactionPoint>> PostTransactionPoint(TransactionPointRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = await _service.Create(request);
            if (id <= 0)
                return BadRequest("Create Failed!");
            var pt = await _context.TransactionPoint.FindAsync(id);

            return CreatedAtAction("GetTransactionPoint", new { id = pt.Id }, pt);
        }

        // DELETE: api/TransactionPoints/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<TransactionPoint>> DeleteTransactionPoint(int id)
        {
            var transactionPoint = await _context.TransactionPoint.FindAsync(id);
            if (transactionPoint == null)
            {
                return NotFound();
            }

            _context.TransactionPoint.Remove(transactionPoint);
            int changed = await _context.SaveChangesAsync();
            if (changed > 1)
                return Ok("Deleted " + changed + " items");
            else if (changed > 0)
                return Ok("Deleted " + changed + " item");
            else
                return BadRequest();
        }

        private bool TransactionPointExists(int id)
        {
            return _context.TransactionPoint.Any(e => e.Id == id);
        }
    }
}
