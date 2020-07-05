using System;
using System.Collections.Generic;
using System.Linq;
using Data.DTO;
using Data.Model;

namespace Data
{
    public class GatekeeperLogRepository : Repository<GatekeeperLog>, IGatekeeperLogRepository
    {
        public GarageContext GarageContext => this.context as GarageContext;
        public GatekeeperLogRepository(GarageContext context) : base(context) {}

        public IEnumerable<GatekeeperReportDto> ReportByLicensePlate(string licensePlate, DateTime begin, DateTime end)
        {
            var result = GarageContext.GatekeeperLogs
                .Where(o => o.LicensePlate == licensePlate && o.Direction == Data.Model.PassOverDirection.In)
                .Select(s => new GatekeeperReportDto
                {
                    LicensePlate = s.LicensePlate,
                    Begin = s.PassOver,
                    End = GarageContext.GatekeeperLogs
                            .Where(i => i.LicensePlate == licensePlate &&
                                        i.Direction == Data.Model.PassOverDirection.Out && i.PassOver >= s.PassOver)
                            .OrderBy(o => o.PassOver)
                            .Select(t => t.PassOver).FirstOrDefault(),
                    Partner = GarageContext.Vehicles.SingleOrDefault(l => l.LicensePlate == s.LicensePlate).Partner.Name,
                    Discount = GarageContext.Vehicles.Where(l => l.LicensePlate == s.LicensePlate)
                                .Select(m => m.Partner.Discount + 
                                             (m.Partner.PaymentPeriod == PaymentPeriod.Weekly 
                                                 ? 0.05m 
                                                 : m.Partner.PaymentPeriod == PaymentPeriod.Monthly 
                                                     ? 0.1m 
                                                     : 0m))
                                .SingleOrDefault(),
                })
                .OrderByDescending(d => d.Begin)
                .ToList();
            
            return result;
        }

        public IEnumerable<GatekeeperReportDto> ReportByCardId(int cardId, DateTime begin, DateTime end)
        {
            var result = GarageContext.GatekeeperLogs
                .Where(o => GarageContext.Partner.Single(p => p.CardId == cardId).Vehicles.Select(q => q.LicensePlate)
                    .Contains(o.LicensePlate) && o.Direction == Data.Model.PassOverDirection.In)
                .Select(s => new GatekeeperReportDto
                {
                    LicensePlate = s.LicensePlate,
                    Begin = s.PassOver,
                    End = GarageContext.GatekeeperLogs
                            .Where(i =>
                                GarageContext.Partner.Single(p => p.CardId == cardId).Vehicles.Select(q => q.LicensePlate)
                                    .Contains(i.LicensePlate) && i.Direction == Data.Model.PassOverDirection.Out && i.PassOver >= s.PassOver)
                            .OrderBy(o => o.PassOver)
                            .Select(t => t.PassOver).FirstOrDefault(),
                    Partner = GarageContext.Vehicles.SingleOrDefault(l => l.LicensePlate == s.LicensePlate).Partner.Name,
                    Discount = GarageContext.Vehicles.Where(l => l.LicensePlate == s.LicensePlate)
                        .Select(m => m.Partner.Discount +
                                     (m.Partner.PaymentPeriod == PaymentPeriod.Weekly
                                         ? 0.05m
                                         : m.Partner.PaymentPeriod == PaymentPeriod.Monthly
                                             ? 0.1m
                                             : 0m))
                        .SingleOrDefault(),
                })
                .OrderByDescending(d => d.Begin)
                .ToList();
            
            return result;
        }
    }
}