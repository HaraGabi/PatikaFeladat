using System;
using System.Collections.Generic;
using Data;
using Data.DTO;

namespace Services
{
    public class QueryService : IQueryService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public QueryService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public IEnumerable<GatekeeperReportDto> ReportByLicensePlate(string licensePlate, DateTime begin, DateTime end)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                return uow.GatekeeperLogs.ReportByLicensePlate(licensePlate, begin, end);
            }
        }

        public IEnumerable<GatekeeperReportDto> ReportByCardId(int cardId, DateTime begin, DateTime end)
        {
            using (var uow = _unitOfWorkFactory.Create())
            {
                return uow.GatekeeperLogs.ReportByCardId(cardId, begin, end);
            }
        }
    }
}