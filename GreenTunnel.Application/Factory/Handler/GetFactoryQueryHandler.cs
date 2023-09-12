using AutoMapper;

using GreenTunnel.Application.Factory.Queries;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;

using MediatR;

namespace GreenTunnel.Application.Factory.Handler;

public class GetFactoryQueryHandler : IRequestHandler<GetFactoryQuery, FactoryViewModel>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IMapper _mapper;

    public GetFactoryQueryHandler(
        IFactoryRepository factoryRepository,
        IMapper mapper)

    {
        _factoryRepository = factoryRepository;
        _mapper = mapper;
    }

    public async Task<FactoryViewModel> Handle(GetFactoryQuery request, CancellationToken cancellationToken)
    {
        var factory = await _factoryRepository.GetSingleOrDefaultAsync(f => f.Id == request.FactoryId);

        if (factory == null)
        {
            // Handle factory not found
            // Return an appropriate response or throw an exception
            return null;
        }

        // Map the factory entity to a view model (you'll need to define FactoryViewModel)
        var factoryViewModel = _mapper.Map<FactoryViewModel>(factory);

        return factoryViewModel;
    }
}
