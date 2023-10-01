using GreenTunnel.Application.Workspaces.Commands.UpdateWorkspace;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Handlers;

public class UpdateWorkSpaceCommandHandler : IRequestHandler<UpdateWorkspaceCommand, CqrsResponseViewModel>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IWorkSpaceRepository _workspaceRepository;

    public UpdateWorkSpaceCommandHandler(IFactoryRepository factoryRepository, IWorkSpaceRepository workspaceRepository)
    {
        _factoryRepository = factoryRepository;
        _workspaceRepository = workspaceRepository;
    }

    public async Task<CqrsResponseViewModel> Handle(UpdateWorkspaceCommand request, CancellationToken cancellationToken)
    {
        var workspace = await _workspaceRepository.GetSingleOrDefaultAsync(f => f.Id == request.Model.Id);

        if (workspace == null)
        {
            return null;
        }

        workspace.Name = request.Model.Name;
        workspace.Description = request.Model.Description;
        workspace.Order = request.Model.Order;
        workspace.UpdatedDate = DateTime.UtcNow;
        workspace.UpdatedBy = request.Model.UpdatedBy; // Set the updated by user ID
        workspace.WorkplaceId = request.Model.WorkplaceId;

        //foreach (var workplaceId in request.Model.WorkplaceIds)
        //{
        //    var existingWorkplace = await _workplaceRepository.GetByIdAsync(workplaceId);

        //    if (existingWorkplace != null)
        //    {
        //        factory.Workplaces.Add(existingWorkplace);
        //    }
        //}

        _workspaceRepository.Update(workspace);

        return new CqrsResponseViewModel(); // Return an appropriate response
    }
}