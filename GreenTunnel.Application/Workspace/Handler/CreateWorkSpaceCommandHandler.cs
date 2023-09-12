using GreenTunnel.Application.Factory.Commands.CreateFactory;
using GreenTunnel.Infrastructure.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Application.Factory.Commands.CreateWorkplace;
using GreenTunnel.Application.Workspace.Commands.CreateWorkspace;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlace;

namespace Workplaces.Handler
{
    public class CreateWorkSpacesCommandHandler : IRequestHandler<CreateWorkspaceCommand, CqrsResponseViewModel>
    {
        private readonly IFactoryRepository _factoryRepository;
        private readonly IWorkSpaceRepository _workSpacesRepository;

        public CreateWorkSpacesCommandHandler(
            IFactoryRepository factoryRepository,
            IWorkSpaceRepository workSpaceRepository)
        {
            _factoryRepository = factoryRepository;
            _workSpacesRepository = workSpaceRepository;
        }

        public async Task<CqrsResponseViewModel> Handle(CreateWorkspaceCommand request, CancellationToken cancellationToken)
        {

            var workspaceModel = new Workspace()
            {
                Name = request.Model.Name,
                Description = request.Model.Description,
                UpdatedDate = DateTime.UtcNow,
                WorkplaceId = request.Model.WorkplaceId,
                Order = request.Model.Order,
                UserId = request.Model.UserId,
                CreatedBy = request.Model.CreatedBy,
                CreatedDate = DateTime.UtcNow,
                // Set other properties
            };

            var workspaceResult = await _workSpacesRepository.AddAsync(workspaceModel);
            return new CreateWorkplaceCommandResponseModel
            {
                WorkPlaceId = workspaceResult.Id
            };
        }
    }
}
