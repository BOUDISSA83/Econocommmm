

using GreenTunnel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenTunnel.Infrastructure.Interfaces
{
    public interface IFactoryRepository : IRepository<Factory>
    {
        Task<Factory> AddAsync(Factory factory);
        IEnumerable<Factory> GetAllCustomersData();
    }
}
