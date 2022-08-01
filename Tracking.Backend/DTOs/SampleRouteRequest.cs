using System;
using System.Collections.Generic;
using Tracking.Backend.Models;

namespace Tracking.Backend.DTOs
{
    public class SampleRouteRequest
    {
        public string RouteCode { get; set; }
        public int UnitId { get; set; }
        public int RouteType { get; set; }  //0 with "PGD", 1 with "ATM"
        public TimeSpan BeginTime { get; set; }
        public List<TracePointForRoute> TracePoits { get; set; }
        public int OverTimeAllowed { get; set; }    //min
        public int ToleranceAllowed { get; set; }   //km
        public int Distance { get; set; }   //km
        public int ArrivalTime { get; set; }    //min
    }
}
