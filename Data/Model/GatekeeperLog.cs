using System;

namespace Data.Model
{
    public class GatekeeperLog
    {
        public int Id { get; set; }
        public string LicensePlate { get; set; }
        public string VehicleColor { get; set; }
        public DateTime PassOver { get; set; }
        public PassOverDirection Direction { get; set; }
    }
}