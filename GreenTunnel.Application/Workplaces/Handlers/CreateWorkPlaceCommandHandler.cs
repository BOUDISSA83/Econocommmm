
using GreenTunnel.Application.Workplaces.Commands.CreateWorkplace;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlaces;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Handlers;

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

        var workplaceModel = new Core.Entities.Workplace()
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