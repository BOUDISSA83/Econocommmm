using AutoMapper;
using GreenTunnel.Application.Factory.Queries;
using GreenTunnel.Application.Workplaces.Queries;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlace;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workplaces.Handler
{
    public class GetWorkplacesListQueryHanlder : IRequestHandler<GetWorkplacesListQuery, List<GetWorkplacesListResponseModel>>
    {
        private readonly IWorkplaceRepository  _workplaceRepository;
        private readonly IMapper _mapper;

        public GetWorkplacesListQueryHanlder(IWorkplaceRepository workplaceRepository,
            IMapper mapper)

        {
            _workplaceRepository = workplaceRepository;
            _mapper = mapper;
        }
        public async Task<List<GetWorkplacesListResponseModel>> Handle(GetWorkplacesListQuery request, CancellationToken cancellationToken)
        {
            var workplacesList = await _workplaceRepository.GetAllWorkplaces();
            var workplaceViewModel = _mapper.Map<List<GetWorkplacesListResponseModel>>(workplacesList);
            return workplaceViewModel;
        }
    }
}
