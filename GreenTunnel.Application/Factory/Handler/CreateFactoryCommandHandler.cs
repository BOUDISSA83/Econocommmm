using MediatR;

using GreenTunnel.Application.Factory.Commands.CreateFactory;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;

namespace GreenTunnel.Application.Factory.Handler;

public class CreateFactoryCommandHandler : IRequestHandler<CreateFactoryCommand, CqrsResponseViewModel>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IWorkplaceRepository _workplaceRepository;

    public CreateFactoryCommandHandler(
        IFactoryRepository factoryRepository,
        IWorkplaceRepository workplaceRepository)
    {
        _factoryRepository = factoryRepository;
        _workplaceRepository = workplaceRepository;
    }

    public class FactoryDto
    {
        public string Name { get; set; }
        // Other properties
        public List<int> WorkplaceIds { get; set; }
    }

    public async Task<CqrsResponseViewModel> Handle(CreateFactoryCommand request, CancellationToken cancellationToken)
    {

        var factoryModel = new Core.Entities.Factory()
        {
            Name = request.Model.Name,
            Email = request.Model.Email,
            Address = request.Model.Address,
            CreatedDate = DateTime.UtcNow,
            Description = request.Model.Description,
            Mobile = request.Model.Mobile,
            Phone = request.Model.Phone,
            Support = request.Model.Support,
            UpdatedDate = DateTime.UtcNow,
            UserId = "",
            CreatedBy = "",
            UpdatedBy = ""
            // Set other properties
        };

        foreach (var workplaceId in request.Model.WorkplaceIds)
        {
            var existingWorkplace = await _workplaceRepository.GetByIdAsync(workplaceId);

            if (existingWorkplace != null)
            {
                factoryModel.Workplaces.Add(existingWorkplace);
            }
        }

        var factoryResult = await _factoryRepository.AddAsync(factoryModel);
        return new CreateFactoryCommandResponseModel
        {
            FactoryId = factoryResult.Id
        };
    }
}
