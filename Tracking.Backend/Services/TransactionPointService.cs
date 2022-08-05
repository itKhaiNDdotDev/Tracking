using System.Threading.Tasks;
using Tracking.Backend.Data;
using Tracking.Backend.DTOs;
using Tracking.Backend.Models;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class TransactionPointService : ITransactionPointService
    {
        private readonly TrackingDbContext _context;
        public TransactionPointService(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(TransactionPointRequest req)
        {
            //throw new System.NotImplementedException();
            TransactionPoint point = new TransactionPoint()
            {
                PointCode = req.PointCode,
                PointName = req.PointName,
                PointType = req.PointType,
                UnitId = req.UnitId,
                Address = req.Address,
                Longtitude = req.Longtitude,
                Latitude = req.Latitude,
                Contact = req.Contact,
                PhoneNumber = req.PhoneNumber,
                Fax = req.Fax,
                Branch = req.Branch,
            };
            _context.TransactionPoint.Add(point);
            await _context.SaveChangesAsync();

            return point.Id;
        }

        public async Task<int> Update(int id, TransactionPointRequest req)
        {
            //throw new System.NotImplementedException();
            var pt = await _context.TransactionPoint.FindAsync(id);
            if (pt == null)
                return -1;
            pt.PointCode = req.PointCode;
            pt.PointName = req.PointName;
            pt.PointType = req.PointType;
            pt.UnitId = req.UnitId;
            pt.Address = req.Address;
            pt.Longtitude = req.Longtitude;
            pt.Latitude = req.Latitude;
            pt.Contact = req.Contact;
            pt.PhoneNumber = req.PhoneNumber;
            pt.Fax = req.Fax;
            pt.Branch = req.Branch;
            _context.TransactionPoint.Update(pt);

            return await _context.SaveChangesAsync();
        }
    }
}
