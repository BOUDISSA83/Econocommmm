using MediatR;

namespace GreenTunnel.Application.Workspaces.Queries;

public class GetDuplicateWorkspaceQuery : IRequest<bool>
{
    public string Name { get; set; }
    public int WorkspaceId { get; set; }
}