using AutoMapper;
using GreenTunnel.Application.Workspaces.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Handlers;

public class GetWorkSpaceQueryHandler : IRequestHandler<GetWorkSpaceQuery, WorkSpaceViewModel>
{
    private readonly IWorkSpaceRepository _workSpaceRepository;
    private readonly IMapper _mapper;

    public GetWorkSpaceQueryHandler(IWorkSpaceRepository workSpaceRepository,
        IMapper mapper)

    {
        _workSpaceRepository = workSpaceRepository;
        _mapper = mapper;
    }

    public async Task<WorkSpaceViewModel> Handle(GetWorkSpaceQuery request, CancellationToken cancellationToken)
    {
        var factory = await _workSpaceRepository.GetByIdDetailsAsync(request.WorkSpaceId);

        if (factory == null)
        {
            // Handle factory not found
            // Return an appropriate response or throw an exception
            return null;
        }

        // Map the factory entity to a view model (you'll need to define FactoryViewModel)
        var workplaceViewModel = _mapper.Map<WorkSpaceViewModel>(factory);

        return workplaceViewModel;
    }
}