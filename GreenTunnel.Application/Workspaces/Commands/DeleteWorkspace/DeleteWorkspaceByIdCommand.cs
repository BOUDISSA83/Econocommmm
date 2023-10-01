using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Commands.DeleteWorkspace;

public class DeleteWorkSpaceCommand : IRequest<CqrsResponseViewModel>
{
    public int WorkspaceId { get; set; }
}