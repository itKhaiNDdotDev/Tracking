using System;
using System.Threading.Tasks;
using Tracking.Backend.Data;
using Tracking.Backend.DTOs;
using Tracking.Backend.Models;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly TrackingDbContext _context;
        public DeviceService(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(DeviceRequest req)
        {
            //throw new System.NotImplementedException();
            Device device = new Device()
            {
                DeviceCode = req.DeviceCode,
                PhoneNumber = req.PhoneNumber,
                MobileCarrier = req.MobileCarrier,
                IsActive = req.IsActive,
                ActiveDate = req.IsActive == true? DateTime.Now : req.ActiveDate,
                UnitId = req.UnitId,
                Imei = req.Imei,
                AllowUpdate = req.AllowUpdate
            };
            _context.Device.Add(device);
            await _context.SaveChangesAsync();

            return device.Id;
        }

        public async Task<int> Update(int id, DeviceRequest req)
        {
            //throw new System.NotImplementedException();
            var device = await _context.Device.FindAsync(id);
            if (device == null)
                return -1;
            device.DeviceCode = req.DeviceCode;
            device.PhoneNumber = req.PhoneNumber;
            device.MobileCarrier = req.MobileCarrier;
            device.IsActive = req.IsActive;
            device.ActiveDate = req.IsActive == true? DateTime.Now : req.ActiveDate;
            device.UnitId = req.UnitId;
            device.Imei = req.Imei;
            device.AllowUpdate = req.AllowUpdate;
            _context.Device.Update(device);

            return await _context.SaveChangesAsync();
        }
    }
}
