using AutoMapper;
using GreenTunnel.Application.Workspaces.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkSpaces;
using MediatR;

namespace GreenTunnel.Application.Workspaces.Handlers;

public class GetWorkspacesListQueryHanlder : IRequestHandler<GetWorkspacesListQuery, List<GetWorkspacesListResponseModel>>
{
    private readonly IWorkSpaceRepository _workspaceRepository;
    private readonly IMapper _mapper;

    public GetWorkspacesListQueryHanlder(IWorkSpaceRepository workspaceRepository,
        IMapper mapper)

    {
        _workspaceRepository = workspaceRepository;
        _mapper = mapper;
    }
    public async Task<List<GetWorkspacesListResponseModel>> Handle(GetWorkspacesListQuery request, CancellationToken cancellationToken)
    {
        var workspacesList = _workspaceRepository.GetAll();
        var workspaceViewModel = _mapper.Map<List<GetWorkspacesListResponseModel>>(workspacesList);
        return workspaceViewModel;
    }
}