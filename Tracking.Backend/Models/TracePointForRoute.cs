namespace Tracking.Backend.Models
{
    public class TracePointForRoute
    {
        public int Id { get; set; }
        public TransactionPoint StopPoint { get; set; }
        public int TravelTimeByMin { get; set; }
    }
}
