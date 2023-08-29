

using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using GreenTunnel.Infrastructure.Interfaces;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class FactoryRepository : Repository<Factory>, IFactoryRepository
    {

        public FactoryRepository(ApplicationDbContext context) : base(context)
        { }

        public IEnumerable<Factory> GetTopActiveCustomers(int count)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Factory> GetAllCustomersData()
        {
            return _appContext.Factories
                .OrderBy(c => c.Name)
                .ToList();
        }

        public async Task<Factory> AddAsync(Factory factory)
        {
            _appContext.Factories.Add(factory);
            await _appContext.SaveChangesAsync();
            return factory;
        }

        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
    }
}
