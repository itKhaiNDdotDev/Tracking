using System;
using System.Collections.Generic;

namespace Tracking.Backend.Models
{
    public class SampleRoute
    {
        // CANT SCF by LIST<>
        public int Id { get; set; }
        public string RouteCode { get; set; }
        public int UnitId { get; set; }
        public int RouteType { get; set; }  //0 with "PGD", 1 with "ATM"
        public TimeSpan BeginTime { get; set; }
        //public string Route { get; set; } //TRACE ROUTE 's'
        //public List<TransactionPoint> TracePoints { get; set; }
        //public List<int> PointTravelTimeByMin { get; set; }
        public List<TracePointForRoute> TracePoits { get; set; }
        public int OverTimeAllowed { get; set; }    //min
        public int ToleranceAllowed { get; set; }   //km
        public int Distance { get; set; }   //km
        public int ArrivalTime { get; set; }    //min
    }
}
