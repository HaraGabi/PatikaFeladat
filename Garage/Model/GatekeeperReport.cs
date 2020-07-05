using System;

namespace Garage.Model
{
    public class GatekeeperReport
    {
        public string LicensePlate { get; set; }
        public DateTime Begin { get; set; }
        public DateTime? End { get; set; }
        public decimal Discount { get; set; }
        public string Partner { get; set; }

        public TimeSpan? Offset => End.HasValue ? End.Value - Begin : (TimeSpan?)null;
    }
}