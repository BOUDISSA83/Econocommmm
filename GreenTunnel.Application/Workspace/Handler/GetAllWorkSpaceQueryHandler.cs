using AutoMapper;
using GreenTunnel.Application.Factory.Queries;
using GreenTunnel.Application.Workplace.Queries;
using GreenTunnel.Application.Workspace.Queries;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workplaces.Handler
{
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
            var workspacesList = await _workplaceRepository.GetWorkSpacesAsync(request.SortColumn, request.SortOrder, request.SearchTerm,request.WorkplaceId,request.PageNumber, request.PageSize);

            var workspacesViewModels = _mapper.Map<List<WorkSpaceViewModel>>(workspacesList.Items);

            var pagedList = new PagedList<WorkSpaceViewModel>(
                 workspacesViewModels,
                 request.PageNumber,
                 request.PageSize,
                 workspacesList.TotalCount);

            return pagedList;
        }
    }
}
