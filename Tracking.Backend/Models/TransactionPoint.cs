namespace Tracking.Backend.Models
{
    public class TransactionPoint
    {
        public int Id { get; set; }
        public string PointCode { get; set; }
        public string PointName { get; set; }
        public int PointType { get; set; }  //0 with "PGD", 1 with "ATM"
        public int UnitId { get; set; }
        public string Address { get; set; }
        public float Longtitude { get; set; }
        public float Latitude { get; set; }
        public string Contact { get; set; }
        public string PhoneNumber { get; set; }
        public string Fax { get; set; }
        public string Branch { get; set; }
    }
}
