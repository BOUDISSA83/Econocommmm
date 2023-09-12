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
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlace;

namespace Workplaces.Handler
{
    public class CreateWorkPlaceCommandHandler : IRequestHandler<CreateWorkplaceCommand, CqrsResponseViewModel>
    {
        private readonly IFactoryRepository _factoryRepository;
        private readonly IWorkplaceRepository _workplaceRepository;

        public CreateWorkPlaceCommandHandler(
            IFactoryRepository factoryRepository,
            IWorkplaceRepository workplaceRepository)
        {
            _factoryRepository = factoryRepository;
            _workplaceRepository = workplaceRepository;
        }
        // Application/Factories/DTOs/FactoryDto.cs
        public class FactoryDto
        {
            public string Name { get; set; }
            // Other properties
            public List<int> WorkplaceIds { get; set; }
        }

        public async Task<CqrsResponseViewModel> Handle(CreateWorkplaceCommand request, CancellationToken cancellationToken)
        {

            var workplaceModel = new Workplace()
            {
                Name = request.Model.Name,
                Description = request.Model.Description,
                UpdatedDate = DateTime.UtcNow,
                UserId = request.Model.UserId,
                CreatedBy = request.Model.CreatedBy,
                FactoryId = request.Model.FactoryId
                // Set other properties
            };
            //foreach (var factoryId in request.Model.FactoriesId)
            //{
            //    var existingWorkplace = await _factoryRepository.(workplaceId);

            //    if (existingWorkplace != null)
            //    {
            //        factoryModel.Workplaces.Add(existingWorkplace);
            //    }
            //}
            var workplaceResult = await _workplaceRepository.AddAsync(workplaceModel);
            return new CreateWorkplaceCommandResponseModel
            {
                WorkPlaceId = workplaceResult.Id
            };
        }
    }
}
