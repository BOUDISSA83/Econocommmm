using AutoMapper;
using GreenTunnel.Application.Workplaces.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlaces;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Handlers;

public class GetWorkplacesListQueryHanlder : IRequestHandler<GetWorkplacesListQuery, List<GetWorkplacesListResponseModel>>
{
    private readonly IWorkplaceRepository _workplaceRepository;
    private readonly IMapper _mapper;

    public GetWorkplacesListQueryHanlder(IWorkplaceRepository workplaceRepository,
        IMapper mapper)

    {
        _workplaceRepository = workplaceRepository;
        _mapper = mapper;
    }
    public async Task<List<GetWorkplacesListResponseModel>> Handle(GetWorkplacesListQuery request, CancellationToken cancellationToken)
    {
        var workplacesList = await _workplaceRepository.GetAllWorkplaces();
        var workplaceViewModel = _mapper.Map<List<GetWorkplacesListResponseModel>>(workplacesList);
        return workplaceViewModel;
    }
}