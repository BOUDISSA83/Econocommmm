using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Workspaces;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Commands.CreateWorkspace;

public class CreateWorkspaceCommand : IRequest<CqrsResponseViewModel>
{
    public CreateWorkspaceRequestViewModel Model { get; }

    public CreateWorkspaceCommand(CreateWorkspaceRequestViewModel model)
    {
        Model = model;
    }
}