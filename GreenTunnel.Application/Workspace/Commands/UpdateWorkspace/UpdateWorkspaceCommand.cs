using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Workplaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workspace.Commands.UpdateWorkspace
{
    public class UpdateWorkspaceCommand : IRequest<CqrsResponseViewModel>
    {
        public UpdateWorkSpaceRequestViewModel Model { get; set; }
    }
}
