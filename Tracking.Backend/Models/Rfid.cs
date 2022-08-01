using System;

namespace Tracking.Backend.Models
{
    public class Rfid
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public DateTime? ActiveDate { get; set; }
        public int UnitId { get; set; }
        public bool Status { get; set; }
    }
}
