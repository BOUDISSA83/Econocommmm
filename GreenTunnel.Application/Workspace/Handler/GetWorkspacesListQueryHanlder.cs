using AutoMapper;
using GreenTunnel.Application.Factory.Queries;
using GreenTunnel.Application.Workplaces.Queries;
using GreenTunnel.Application.Workspaces.Queries;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlace;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkSpace;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workspaces.Handler
{
    public class GetWorkspacesListQueryHanlder : IRequestHandler<GetWorkspacesListQuery, List<GetWorkspacesListResponseModel>>
    {
        private readonly IWorkSpaceRepository  _workspaceRepository;
        private readonly IMapper _mapper;

        public GetWorkspacesListQueryHanlder(IWorkSpaceRepository workspaceRepository,
            IMapper mapper)

        {
            _workspaceRepository = workspaceRepository;
            _mapper = mapper;
        }
        public async Task<List<GetWorkspacesListResponseModel>> Handle(GetWorkspacesListQuery request, CancellationToken cancellationToken)
        {
            var workspacesList =  _workspaceRepository.GetAll();
            var workspaceViewModel = _mapper.Map<List<GetWorkspacesListResponseModel>>(workspacesList);
            return workspaceViewModel;
        }
    }
}
