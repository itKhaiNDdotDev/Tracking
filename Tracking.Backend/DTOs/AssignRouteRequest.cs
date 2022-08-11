using System;

namespace Tracking.Backend.DTOs
{
    public class AssignRouteRequest
    {
        public int UnitId { get; set; }
        public int CarId { get; set; }
        public int DriverId { get; set; }
        public int RouteId { get; set; }
        public int TreasurerId { get; set; }
        public int? AtmTechnicanId { get; set; }
        public string Guard { get; set; }
        public TimeSpan BeginTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Mon { get; set; }
        public bool Tue { get; set; }
        public bool Wed { get; set; }
        public bool Thu { get; set; }
        public bool Fri { get; set; }
        public bool Sat { get; set; }
        public bool Sun { get; set; }
        public bool IssueComand { get; set; }
        public bool sendSMS { get; set; }
    }
}
