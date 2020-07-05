using System;
using System.Collections.Generic;
using Data.DTO;
using Data.Model;

namespace Data
{
    public interface IGatekeeperLogRepository : IRepository<GatekeeperLog>
    {
        IEnumerable<GatekeeperReportDto> ReportByLicensePlate(string licensePlate, DateTime begin, DateTime end);
        IEnumerable<GatekeeperReportDto> ReportByCardId(int cardId, DateTime begin, DateTime end);
    }
}