

using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace GreenTunnel.Repositories.Interfaces
{
    public interface IWorkplaceRepository : IRepository<Workplace>
    {
        Task<Workplace> GetByIdAsync(int id);

    }
}
