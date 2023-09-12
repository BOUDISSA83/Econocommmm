using AutoMapper;

using GreenTunnel.Application.Factory.Queries;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;

using MediatR;

namespace GreenTunnel.Application.Factory.Handler;

public class GetFactoriesListQueryHanlder : IRequestHandler<GetFactoriesListQuery, List<GetFacoriesListResponseModel>>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IMapper _mapper;

    public GetFactoriesListQueryHanlder(
        IFactoryRepository factoryRepository,
        IMapper mapper)
    {
        _factoryRepository = factoryRepository;
        _mapper = mapper;
    }

    public async Task<List<GetFacoriesListResponseModel>> Handle(GetFactoriesListQuery request, CancellationToken cancellationToken)
    {
        var factoriesList = await _factoryRepository.GetAllFactories();
        var factoryViewModel = _mapper.Map<List<GetFacoriesListResponseModel>>(factoriesList);
        return factoryViewModel;
    }
}
