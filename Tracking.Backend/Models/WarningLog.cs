using System;

namespace Tracking.Backend.Models
{
    public class WarningLog
    {
        public int Id { get; set; }
        public int AssignRouteId { get; set; }
        public int Type { get; set; } // 0 - SOS, 1 - Sai lo trinh, 2 - Tre thoi gian
        public string Message { get; set; }
        public DateTime SendTime { get; set; }
    }
}
