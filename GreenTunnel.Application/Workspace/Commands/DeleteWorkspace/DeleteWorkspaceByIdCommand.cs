using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workspace.Commands.DeleteWorkspace
{
    public class DeleteWorkSpaceCommand : IRequest<CqrsResponseViewModel>
    {
        public int WorkspaceId { get; set; }
    }
}
