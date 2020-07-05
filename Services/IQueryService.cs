using System;
using System.Collections.Generic;
using Data.DTO;

namespace Services
{
    public interface IQueryService
    {
        IEnumerable<GatekeeperReportDto> ReportByLicensePlate(string licensePlate, DateTime begin, DateTime end);
        IEnumerable<GatekeeperReportDto> ReportByCardId(int cardId, DateTime begin, DateTime end);
    }
}