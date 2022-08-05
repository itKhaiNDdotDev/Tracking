using System;

namespace Tracking.Backend.Models
{
    public class Device
    {
        public int Id { get; set; }
        public string DeviceCode { get; set; }
        public string PhoneNumber { get; set; }
        public string MobileCarrier { get; set; }
        public DateTime? ActiveDate { get; set; }
        public int UnitId { get; set; }
        public string Imei { get; set; }
        public bool IsActive { get; set; }
        public bool AllowUpdate { get; set; }
    }
}
