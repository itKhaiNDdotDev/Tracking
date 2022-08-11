namespace Tracking.Backend.DTOs
{
    public class WarningRequest
    {
        public int Type { get; set; } // 0 - SOS, 1 - Sai lo trinh, 2 - Tre thoi gian
        public string Message { get; set; }
    }
}
