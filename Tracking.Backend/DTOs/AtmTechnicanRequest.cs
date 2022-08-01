﻿namespace Tracking.Backend.DTOs
{
    public class AtmTechnicanRequest
    {
        public string Image { get; set; }
        public string EmployeeCode { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int? RfidId { get; set; }
        public int UnitId { get; set; }
        public bool OffJob { get; set; }
    }
}
