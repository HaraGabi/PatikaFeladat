using System;
using System.Collections.Generic;

namespace Data.Model
{
    public class Partner
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Discount { get; set; }
        public DateTime Begin { get; set; }
        public DateTime? End { get; set; }
        public PaymentPeriod PaymentPeriod { get; set; }

        public int? CardId { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}