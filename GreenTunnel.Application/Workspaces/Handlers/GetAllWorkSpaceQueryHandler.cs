using AutoMapper;
using GreenTunnel.Application.Workspaces.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Handlers;

public class GetAllWorkSpaceQueryHandler : IRequestHandler<GetAllWorkspaceQuery, PagedList<WorkSpaceViewModel>>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IMapper _mapper;
    private readonly IWorkSpaceRepository _workplaceRepository;

    public GetAllWorkSpaceQueryHandler(
        IFactoryRepository factoryRepository,
        IMapper mapper,
        IWorkSpaceRepository workplaceRepository)
    {
        _factoryRepository = factoryRepository;
        _mapper = mapper;
        _workplaceRepository = workplaceRepository;
    }
    public async Task<PagedList<WorkSpaceViewModel>> Handle(GetAllWorkspaceQuery request, CancellationToken cancellationToken)
    {
        var workspacesList = await _workplaceRepository.GetWorkSpacesAsync(request.SortColumn, request.SortOrder, request.SearchTerm, request.WorkplaceId, request.PageNumber, request.PageSize);

        var workspacesViewModels = _mapper.Map<List<WorkSpaceViewModel>>(workspacesList.Items);

        var pagedList = new PagedList<WorkSpaceViewModel>(
            workspacesViewModels,
            request.PageNumber,
            request.PageSize,
            workspacesList.TotalCount);

        return pagedList;
    }
}