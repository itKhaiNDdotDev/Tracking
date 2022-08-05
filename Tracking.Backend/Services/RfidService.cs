using System;
using System.Threading.Tasks;
using Tracking.Backend.Data;
using Tracking.Backend.DTOs;
using Tracking.Backend.Models;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class RfidService : IRfidService
    {
        private readonly TrackingDbContext _context;
        public RfidService(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(RfidRequest req)
        {
            //throw new System.NotImplementedException();
            Rfid rfid = new Rfid()
            {
                CardNumber = req.CardNumber,
                Description = req.Description,
                Type = req.Type,
                UnitId = req.UnitId,
                Status = req.Status,
                ActiveDate = req.Status == true? DateTime.Now : req.ActiveDate
            };
            _context.Rfid.Add(rfid);
            await _context.SaveChangesAsync();

            return rfid.Id;
        }

        public async Task<int> Update(int id, RfidRequest req)
        {
            //throw new System.NotImplementedException();
            var rfid = await _context.Rfid.FindAsync(id);
            if (rfid == null)
                return -1;
            rfid.CardNumber = req.CardNumber;
            rfid.Description = req.Description;
            rfid.Type = req.Type;
            rfid.UnitId = req.UnitId;
            rfid.Status = req.Status;
            rfid.ActiveDate = req.Status == true? DateTime.Now : req.ActiveDate;
            _context.Rfid.Update(rfid);

            return await _context.SaveChangesAsync();
        }
    }
}
