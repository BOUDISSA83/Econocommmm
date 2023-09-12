

using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.Interfaces;
using System;
using System.Linq;

namespace GreenTunnel.Infrastructure
{
    public interface IUnitOfWork
    {
        IFactoryRepository Factories { get; }
        IWorkSpaceRepository Workspaces { get; }
        IWorkplaceRepository Workplaces { get; }

        int SaveChanges();
    }
}
