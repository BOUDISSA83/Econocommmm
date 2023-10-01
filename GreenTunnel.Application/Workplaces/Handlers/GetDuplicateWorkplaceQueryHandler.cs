using AutoMapper;
using GreenTunnel.Application.Workplaces.Queries;
using GreenTunnel.Core.Interfaces;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Handlers;

public class GetDuplicateWorkplaceQueryHandler : IRequestHandler<GetDuplicateWorkplaceQuery, bool>
{
    private readonly IWorkplaceRepository _workplaceRepository;
    private readonly IMapper _mapper;

    public GetDuplicateWorkplaceQueryHandler(IWorkplaceRepository factoryRepository)

        {
            _workplaceRepository = factoryRepository;
        }
        public async Task<bool> Handle(GetDuplicateWorkplaceQuery request, CancellationToken cancellationToken)
        {
            // Check for duplicate Workplace with the same name but a different ID
            var existingWorkplace = await _workplaceRepository.GetSingleOrDefaultAsync(f => f.Name.Contains(request.Name) && f.Id == request.WorkplaceId);
            if (request.WorkplaceId > 0)
            {
                if (existingWorkplace != null)
                {
                    // A duplicate Workplace was found with a different ID, return false
                    return false;
                }
                else
                {
                    existingWorkplace = await _workplaceRepository.GetSingleOrDefaultAsync(f => f.Name.Equals(request.Name) && f.Id != request.WorkplaceId);
                    if (existingWorkplace != null)
                    {
                        // A duplicate Workplace was found with a different ID, return false
                        return true;
                    }
                }
            }
            else
            {
                existingWorkplace = await _workplaceRepository.GetSingleOrDefaultAsync(f => f.Name.Equals(request.Name) && f.Id != request.WorkplaceId);
                if (existingWorkplace != null)
                {
                    // A duplicate Workplace was found with a different ID, return false
                    return true;
                }
            }
            return false;
        }

}
