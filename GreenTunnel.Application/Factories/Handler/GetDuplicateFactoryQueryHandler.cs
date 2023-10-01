using AutoMapper;
using GreenTunnel.Application.Factories.Queries;
using GreenTunnel.Core.Interfaces;
using MediatR;

namespace GreenTunnel.Application.Factories.Handler;

public class GetDuplicateFactoryQueryHandler : IRequestHandler<GetDuplicateFactoryQuery, bool>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IMapper _mapper;

    public GetDuplicateFactoryQueryHandler(IFactoryRepository factoryRepository)

        {
            _factoryRepository = factoryRepository;
        }
        public async Task<bool> Handle(GetDuplicateFactoryQuery request, CancellationToken cancellationToken)
        {
            // Check for duplicate Factory with the same name but a different ID
            var existingFactory = await _factoryRepository.GetSingleOrDefaultAsync(f => f.Name.Contains(request.Name) && f.Id == request.FactoryId);
            if (request.FactoryId > 0)
            {
                if (existingFactory != null)
                {
                    // A duplicate Factory was found with a different ID, return false
                    return false;
                }
                else
                {
                    existingFactory = await _factoryRepository.GetSingleOrDefaultAsync(f => f.Name.Equals(request.Name) && f.Id != request.FactoryId);
                    if (existingFactory != null)
                    {
                        // A duplicate Factory was found with a different ID, return false
                        return true;
                    }
                }
            }
            else
            {
                existingFactory = await _factoryRepository.GetSingleOrDefaultAsync(f => f.Name.Equals(request.Name) && f.Id != request.FactoryId);
                if (existingFactory != null)
                {
                    // A duplicate Factory was found with a different ID, return false
                    return true;
                }
            }
            return false;
        }
    
}
