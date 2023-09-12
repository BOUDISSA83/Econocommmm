using GreenTunnel.Application.Factory.Commands.DeleteFactory;
using GreenTunnel.Application.Workplace.Commands.DeleteWorkplace;
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
    public class DeleteWorkplaceCommandHandler : IRequestHandler<DeleteWorkplaceCommand, CqrsResponseViewModel>
    {
        private readonly IFactoryRepository _factoryRepository;
        private readonly IWorkplaceRepository _workplaceRepository;

        public DeleteWorkplaceCommandHandler(IFactoryRepository factoryRepository, IWorkplaceRepository workplaceRepository)
        {
            _workplaceRepository = workplaceRepository;
        }

        public async Task<CqrsResponseViewModel> Handle(DeleteWorkplaceCommand request, CancellationToken cancellationToken)
        {
            var workplace = await _workplaceRepository.GetSingleOrDefaultAsync(f => f.Id == request.WorkplaceId);

            if (workplace == null)
            {
                return null;
            }

            _workplaceRepository.Remove(workplace);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }
}
