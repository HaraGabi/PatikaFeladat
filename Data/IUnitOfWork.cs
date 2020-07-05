using System;

namespace Data
{
    public interface IUnitOfWork : IDisposable
    {
        IGatekeeperLogRepository GatekeeperLogs { get; }
        int Complete();
    }
}