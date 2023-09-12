using GreenTunnel.Application.Factory.Commands.DeleteFactory;
using GreenTunnel.Application.Workplace.Commands.DeleteWorkplace;
using GreenTunnel.Application.Workspace.Commands.DeleteWorkspace;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workplaces.Handler
{
    public class DeleteWorkSpaceCommandHandler : IRequestHandler<DeleteWorkSpaceCommand, CqrsResponseViewModel>
    {
        private readonly IFactoryRepository _factoryRepository;
        private readonly IWorkSpaceRepository _workspaceRepository;

        public DeleteWorkSpaceCommandHandler(IFactoryRepository factoryRepository, IWorkSpaceRepository workspaceRepository)
        {
            _factoryRepository = factoryRepository;
            _workspaceRepository = workspaceRepository;
        }

        public async Task<CqrsResponseViewModel> Handle(DeleteWorkSpaceCommand request, CancellationToken cancellationToken)
        {
            var workspace = await _workspaceRepository.GetSingleOrDefaultAsync(f => f.Id == request.WorkspaceId);

            if (workspace == null)
            {
                return null;
            }

            _workspaceRepository.Remove(workspace);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }
}
