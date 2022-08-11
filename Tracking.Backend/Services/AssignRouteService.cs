using System.Threading.Tasks;
using Tracking.Backend.Data;
using Tracking.Backend.DTOs;
using Tracking.Backend.Models;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class AssignRouteService : IAssignRouteService
    {
        private readonly TrackingDbContext _context;
        public AssignRouteService(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(AssignRouteRequest req)
        {
            //throw new System.NotImplementedException();
            AssignRoute aRoute = new AssignRoute()
            {
                UnitId = req.UnitId,
                CarId = req.CarId,
                DriverId = req.DriverId,
                RouteId = req.RouteId,
                TreasurerId = req.TreasurerId,
                AtmTechnicanId = req.AtmTechnicanId,
                Guard = req.Guard,
                BeginTime = req.BeginTime,
                EndTime = req.EndTime,
                BeginDate = req.BeginDate,
                EndDate = req.EndDate,
                Mon = req.Mon,
                Tue = req.Tue,
                Wed = req.Wed,
                Thu = req.Thu,
                Fri = req.Fri,
                Sat = req.Sat,
                Sun = req.Sun,
                IssueComand = req.IssueComand,
                sendSMS = req.sendSMS
            };
            _context.AssignRoute.Add(aRoute);
            await _context.SaveChangesAsync();

            return aRoute.Id;
        }

        public async Task<int> Update(int id, AssignRouteRequest req)
        {
            //throw new System.NotImplementedException();
            var aRoute = await _context.AssignRoute.FindAsync(id);
            if (aRoute == null)
                return -1;
            aRoute.UnitId = req.UnitId;
            aRoute.CarId = req.CarId;
            aRoute.DriverId = req.DriverId;
            aRoute.RouteId = req.RouteId;
            aRoute.TreasurerId = req.TreasurerId;
            aRoute.AtmTechnicanId = req.AtmTechnicanId;
            aRoute.Guard = req.Guard;
            aRoute.BeginTime = req.BeginTime;
            aRoute.EndTime = req.EndTime;
            aRoute.BeginDate = req.BeginDate;
            aRoute.EndDate = req.EndDate;
            aRoute.Mon = req.Mon;
            aRoute.Tue = req.Tue;
            aRoute.Wed = req.Wed;
            aRoute.Thu = req.Thu;
            aRoute.Fri = req.Fri;
            aRoute.Sat = req.Sat;
            aRoute.Sun = req.Sun;
            aRoute.IssueComand = req.IssueComand;
            aRoute.sendSMS = req.sendSMS;
            _context.AssignRoute.Update(aRoute);

            return await _context.SaveChangesAsync();
        }
    }
}
