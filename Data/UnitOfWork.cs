namespace Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GarageContext _context;

        public UnitOfWork(GarageContext context)
        {
            _context = context;
            GatekeeperLogs = new GatekeeperLogRepository(_context);
        }

        public IGatekeeperLogRepository GatekeeperLogs { get; }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}