using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workspace.Queries
{
    public class GetWorkSpaceQuery : IRequest<WorkSpaceViewModel>
    {
        public int WorkSpaceId { get; set; }
    }
}
