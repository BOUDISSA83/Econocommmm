using GreenTunnel.Infrastructure.ViewModels.Response.WorkSpaces;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Queries;

public class GetWorkspacesListQuery : IRequest<List<GetWorkspacesListResponseModel>>
{
}