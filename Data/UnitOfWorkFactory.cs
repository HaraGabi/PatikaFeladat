using System;
using Microsoft.Extensions.DependencyInjection;

namespace Data
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        private readonly IServiceProvider _services;

        public UnitOfWorkFactory(IServiceProvider services)
        {
            _services = services;
        }

        public IUnitOfWork Create()
        {
            return new UnitOfWork(_services.GetRequiredService<GarageContext>());
        }
    }
}