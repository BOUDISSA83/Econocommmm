
namespace GreenTunnel.Core.Interfaces.Uow;

public interface IUnitOfWork
{
    IFactoryRepository Factories { get; }
    IWorkSpaceRepository Workspaces { get; }
    IWorkplaceRepository Workplaces { get; }

    int SaveChanges();
}