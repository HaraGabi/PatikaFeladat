using System;

namespace Data.DTO
{
    public class GatekeeperReportDto
    {
        public string LicensePlate { get; set; }
        public DateTime Begin { get; set; }
        public DateTime? End { get; set; }

        public decimal Discount { get; set; }
        public string Partner { get; set; }
    }
}