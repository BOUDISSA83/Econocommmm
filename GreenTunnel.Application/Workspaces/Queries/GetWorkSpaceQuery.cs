using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Queries;

public class GetWorkSpaceQuery : IRequest<WorkSpaceViewModel>
{
    public int WorkSpaceId { get; set; }
}