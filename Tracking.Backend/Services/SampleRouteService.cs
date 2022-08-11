using System.Collections.Generic;
using System.Threading.Tasks;
using Tracking.Backend.Data;
using Tracking.Backend.DTOs;
using Tracking.Backend.Models;
using Tracking.Backend.Services.InterfaceDIServices;

namespace Tracking.Backend.Services
{
    public class SampleRouteService : ISampleRouteService
    {
        private readonly TrackingDbContext _context;
        public SampleRouteService(TrackingDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(SampleRouteRequest req)
        {
            //throw new System.NotImplementedException();
            SampleRoute spRoute = new SampleRoute()
            {
                RouteCode = req.RouteCode,
                UnitId = req.UnitId,
                RouteType = req.RouteType,
                BeginTime = req.BeginTime,
                OverTimeAllowed = req.OverTimeAllowed,
                ToleranceAllowed = req.ToleranceAllowed,
                Distance = req.Distance,
                ArrivalTime = req.ArrivalTime,
            };
            List<TracePointId> tmp = req.TracePoints;
            spRoute.TracePoits = new List<TracePointForRoute>();
            foreach (var tracePoint in tmp)
            {
                //new TracePointForRoute()
                //{
                //    StopPoint = await _context.TransactionPoint.FindAsync(tracePoint.PointId),
                //    TravelTimeByMin = tracePoint.TimeTravelTimeByMin
                //};
                spRoute.TracePoits.Add(new TracePointForRoute()
                {
                    StopPoint = await _context.TransactionPoint.FindAsync(tracePoint.PointId),
                    TravelTimeByMin = tracePoint.TimeTravelTimeByMin
                });
            }
             
            _context.SampleRoutes.Add(spRoute);
            await _context.SaveChangesAsync();

            return spRoute.Id;
        }

        public async Task<int> Update(int id, SampleRouteRequest req)
        {
            //throw new System.NotImplementedException();
            var spRoute = await _context.SampleRoutes.FindAsync(id);
            if (spRoute == null)
                return -1;
            spRoute.RouteCode = req.RouteCode;
            spRoute.UnitId = req.UnitId;
            spRoute.RouteType = req.RouteType;
            spRoute.BeginTime = req.BeginTime;
            spRoute.OverTimeAllowed = req.OverTimeAllowed;
            spRoute.ToleranceAllowed = req.ToleranceAllowed;
            spRoute.Distance = req.Distance;
            spRoute.ArrivalTime = req.ArrivalTime;
            List<TracePointId> tmp = req.TracePoints;
            spRoute.TracePoits = new List<TracePointForRoute>();
            foreach (var tracePoint in tmp)
            {
                new TracePointForRoute()
                {
                    StopPoint = await _context.TransactionPoint.FindAsync(tracePoint.PointId),
                    TravelTimeByMin = tracePoint.TimeTravelTimeByMin
                };
            }
            _context.SampleRoutes.Update(spRoute);

            return await _context.SaveChangesAsync();
        }
    }
}
