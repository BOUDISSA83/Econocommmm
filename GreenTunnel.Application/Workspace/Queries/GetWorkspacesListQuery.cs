using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlace;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkSpace;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workspaces.Queries
{
    public class GetWorkspacesListQuery : IRequest<List<GetWorkspacesListResponseModel>>
    {
    }
}
