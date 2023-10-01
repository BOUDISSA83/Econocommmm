using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlaces;
using GreenTunnel.Application.Workspaces.Commands.CreateWorkspace;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Handlers;

public class CreateWorkspacesCommandHandler : IRequestHandler<CreateWorkspaceCommand, CqrsResponseViewModel>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IWorkSpaceRepository _workSpacesRepository;

    public CreateWorkspacesCommandHandler(
        IFactoryRepository factoryRepository,
        IWorkSpaceRepository workSpaceRepository)
    {
        _factoryRepository = factoryRepository;
        _workSpacesRepository = workSpaceRepository;
    }

    public async Task<CqrsResponseViewModel> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
    {

        var workspaceModel = new Workspace()
        {
            Name = request.Model.Name,
            Description = request.Model.Description,
            UpdatedDate = DateTime.UtcNow,
            WorkplaceId = request.Model.WorkplaceId,
            Order = request.Model.Order,
            UserId = request.Model.UserId,
            CreatedBy = request.Model.CreatedBy,
            CreatedDate = DateTime.UtcNow,
            // Set other properties
        };

        var workspaceResult = await _workSpacesRepository.AddAsync(workspaceModel);
        return new CreateWorkplaceCommandResponseModel
        {
            WorkPlaceId = workspaceResult.Id
        };
    }
}