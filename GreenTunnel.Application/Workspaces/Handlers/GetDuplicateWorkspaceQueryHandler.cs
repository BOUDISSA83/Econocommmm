using AutoMapper;
using GreenTunnel.Application.Workspaces.Queries;
using GreenTunnel.Core.Interfaces;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Handlers;

public class GetDuplicateWorkspaceQueryHandler : IRequestHandler<GetDuplicateWorkspaceQuery, bool>
{
    private readonly IWorkSpaceRepository _workspaceRepository;
    private readonly IMapper _mapper;

    public GetDuplicateWorkspaceQueryHandler(IWorkSpaceRepository workplaceRepository)

    {
        _workspaceRepository = workplaceRepository;
    }
    public async Task<bool> Handle(GetDuplicateWorkspaceQuery request, CancellationToken cancellationToken)
    {
        var existingWorkspace = await _workspaceRepository.GetSingleOrDefaultAsync(f => f.Name.Contains(request.Name) && f.Id == request.WorkspaceId);
        if (request.WorkspaceId > 0)
        {
            if (existingWorkspace != null)
            {
                // A duplicate Workspace was found with a different ID, return false
                return false;
            }
            else
            {
                existingWorkspace = await _workspaceRepository.GetSingleOrDefaultAsync(f => f.Name.Equals(request.Name) && f.Id != request.WorkspaceId);
                if (existingWorkspace != null)
                {
                    // A duplicate Workspace was found with a different ID, return false
                    return true;
                }
            }
        }
        else
        {
            existingWorkspace = await _workspaceRepository.GetSingleOrDefaultAsync(f => f.Name.Equals(request.Name) && f.Id != request.WorkspaceId);
            if (existingWorkspace != null)
            {
                // A duplicate Workspace was found with a different ID, return false
                return true;
            }
        }
        return false;
    }
}