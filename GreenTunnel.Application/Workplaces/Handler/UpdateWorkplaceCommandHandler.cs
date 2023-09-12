using GreenTunnel.Application.Factory.Commands.UpdateFactory;
using GreenTunnel.Application.Workplace.Commands.UpdateWorkplace;
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
    public class UpdateWorkplaceCommandHandler : IRequestHandler<UpdateWorkplaceCommand, CqrsResponseViewModel>
    {
        private readonly IFactoryRepository _factoryRepository;
        private readonly IWorkplaceRepository _workplaceRepository;

        public UpdateWorkplaceCommandHandler(IFactoryRepository factoryRepository, IWorkplaceRepository workplaceRepository)
        {
            _factoryRepository = factoryRepository;
            _workplaceRepository = workplaceRepository;
        }

        public async Task<CqrsResponseViewModel> Handle(UpdateWorkplaceCommand request, CancellationToken cancellationToken)
        {
            var workplace = await _workplaceRepository.GetSingleOrDefaultAsync(f => f.Id == request.Model.Id);

            if (workplace == null)
            {
                return null;
            }

            workplace.Name = request.Model.Name;
            workplace.Description = request.Model.Description;
            workplace.UpdatedDate = DateTime.UtcNow;
            workplace.UpdatedBy = request.Model.UpdatedBy; // Set the updated by user ID
            workplace.FactoryId = request.Model.FactoryId;
            workplace.Workspaces.Clear(); // Clear existing workplaces

            //foreach (var workplaceId in request.Model.WorkplaceIds)
            //{
            //    var existingWorkplace = await _workplaceRepository.GetByIdAsync(workplaceId);

            //    if (existingWorkplace != null)
            //    {
            //        factory.Workplaces.Add(existingWorkplace);
            //    }
            //}

            _workplaceRepository.Update(workplace);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }
}
