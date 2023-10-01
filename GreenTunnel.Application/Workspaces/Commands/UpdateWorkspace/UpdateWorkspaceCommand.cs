using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Workspaces;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Commands.UpdateWorkspace;

public class UpdateWorkspaceCommand : IRequest<CqrsResponseViewModel>
{
    public UpdateWorkSpaceRequestViewModel Model { get; set; }
}