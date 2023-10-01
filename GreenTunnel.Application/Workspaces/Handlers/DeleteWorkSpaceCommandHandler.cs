using GreenTunnel.Application.Workspaces.Commands.DeleteWorkspace;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Handlers;

public class DeleteWorkSpaceCommandHandler : IRequestHandler<DeleteWorkSpaceCommand, CqrsResponseViewModel>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IWorkSpaceRepository _workspaceRepository;

    public DeleteWorkSpaceCommandHandler(IFactoryRepository factoryRepository, IWorkSpaceRepository workspaceRepository)
    {
        _factoryRepository = factoryRepository;
        _workspaceRepository = workspaceRepository;
    }

    public async Task<CqrsResponseViewModel> Handle(DeleteWorkSpaceCommand request, CancellationToken cancellationToken)
    {
        var workspace = await _workspaceRepository.GetSingleOrDefaultAsync(f => f.Id == request.WorkspaceId);

        if (workspace == null)
        {
            return null;
        }

        _workspaceRepository.Remove(workspace);

        return new CqrsResponseViewModel(); // Return an appropriate response
    }
}