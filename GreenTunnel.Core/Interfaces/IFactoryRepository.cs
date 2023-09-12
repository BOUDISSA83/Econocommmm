

using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GreenTunnel.Core.Repositories.Interfaces
{
    public interface IFactoryRepository : IRepository<Factory>
    {
        Task<Factory> AddAsync(Factory factory);
        Task<List<Factory>> GetAllFactories();
        Task<PagedList<Factory>> GetFactoriesAsync(string? sortColumn, string? sortOrder,string? searchTerm, int page, int pageSize);

    }
}
