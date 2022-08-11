﻿using System;
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
    public class DevicesController : ControllerBase
    {
        private readonly TrackingDbContext _context;
        private readonly IDeviceService _service;
        public DevicesController(TrackingDbContext context, IDeviceService service)
        {
            _context = context;
            _service = service;
        }

        // GET: api/Devices
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Device>>> GetAll()
        {
            return await _context.Device.ToListAsync();
        }

        // GET: api/Devices/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Device>> GetDevice(int id)
        {
            var device = await _context.Device.FindAsync(id);

            if (device == null)
            {
                return NotFound();
            }

            return device;
        }

        // PUT: api/Devices/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDevice(int id, DeviceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int changed = await _service.Update(id, request);
            try
            {
                if (changed == -1)
                    return NotFound("Device with id = " + id + " is not exist!");
                if (changed == 0)
                    return BadRequest("Update Failed!");
                var device = await _context.Device.FindAsync(id);
                if (device == null)
                {
                    return NotFound();
                }
                return Ok(device);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
        }

        // POST: api/Devices
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Device>> PostDevice(DeviceRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            int id = await _service.Create(request);
            if (id <= 0)
                return BadRequest("Create Failed!");
            var device = await _context.Device.FindAsync(id);

            return CreatedAtAction("GetDevice", new { id = device.Id }, device);
        }

        // DELETE: api/Devices/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Device>> DeleteDevice(int id)
        {
            var device = await _context.Device.FindAsync(id);
            if (device == null)
            {
                return NotFound();
            }

            _context.Device.Remove(device);
            int changed = await _context.SaveChangesAsync();
            if (changed > 1)
                return Ok("Deleted " + changed + " items");
            else if (changed > 0)
                return Ok("Deleted " + changed + " item");
            else
                return BadRequest();
        }

        private bool DeviceExists(int id)
        {
            return _context.Device.Any(e => e.Id == id);
        }
    }
}
