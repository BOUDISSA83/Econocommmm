using AutoMapper;
using GreenTunnel.Application.Factories.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;

namespace GreenTunnel.Application.Factories.Handler;

public class GetFactoriesQueryHandler : IRequestHandler<GetAllFactoryQuery, PagedList<FactoryViewModel>>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IMapper _mapper;
    private readonly IWorkplaceRepository _workplaceRepository;

    public GetFactoriesQueryHandler(
        IFactoryRepository factoryRepository,
        IMapper mapper,
        IWorkplaceRepository workplaceRepository)
    {
        _factoryRepository = factoryRepository;
        _mapper = mapper;
        _workplaceRepository = workplaceRepository;
    }
    public async Task<PagedList<FactoryViewModel>> Handle(GetAllFactoryQuery request, CancellationToken cancellationToken)
    {
        var factoriesList = await _factoryRepository.GetFactoriesAsync(request.SortColumn, request.SortOrder, request.SearchTerm, request.PageNumber, request.PageSize);

        var factoryViewModels = _mapper.Map<List<FactoryViewModel>>(factoriesList.Items);

        var pagedList = new PagedList<FactoryViewModel>(
            factoryViewModels,
            request.PageNumber,
            request.PageSize,
            factoriesList.TotalCount);

        return pagedList;
    }
}