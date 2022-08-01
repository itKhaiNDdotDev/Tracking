namespace Tracking.Backend.DTOs
{
    public class CarRequest
    {
        public string LicensePlate { get; set; }
        public string Type { get; set; }
        public int DeviceId { get; set; }
        public int UnitId { get; set; }
        public int DriverId { get; set; }
        public int NumberCamera { get; set; }
        public string FirstCam { get; set; }
        public int FirstCamRotation { get; set; }
        public int SecondCamRotation { get; set; }
        public string FuelType { get; set; }
        public float? Fuel { get; set; }
        public string Uom { get; set; }
        public int LimitedSpeed { get; set; }
    }
}
