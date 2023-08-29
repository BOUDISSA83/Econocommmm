

using GreenTunnel.Infrastructure.Interfaces;
using GreenTunnel.Repositories.Interfaces;


namespace GreenTunnel.Infrastructure
{
    public interface IUnitOfWork
    {
        IFactoryRepository Factories { get; }
        IWorkspaceRepository Workspaces { get; }
        IWorkplaceRepository Workplaces { get; }

        int SaveChanges();
    }
}
