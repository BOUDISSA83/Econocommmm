using AutoMapper;
using GreenTunnel.Application.Workplaces.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Handlers;

public class GetWorkplaceQueryHandler : IRequestHandler<GetWorkplaceQuery, WorkplaceViewModel>
{
    private readonly IWorkplaceRepository _workplaceRepository;
    private readonly IMapper _mapper;

    public GetWorkplaceQueryHandler(IWorkplaceRepository workplaceRepository,
        IMapper mapper)

    {
        _workplaceRepository = workplaceRepository;
        _mapper = mapper;
    }

    public async Task<WorkplaceViewModel> Handle(GetWorkplaceQuery request, CancellationToken cancellationToken)
    {
        var workplace = await _workplaceRepository.GetByIdDetailsAsync(request.WorkplaceId);

        if (workplace == null)
        {
            // Handle factory not found
            // Return an appropriate response or throw an exception
            return null;
        }

        // Map the factory entity to a view model (you'll need to define FactoryViewModel)
        var workplaceViewModel = _mapper.Map<WorkplaceViewModel>(workplace);

        return workplaceViewModel;
    }
}