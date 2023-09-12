using AutoMapper;
using GreenTunnel.Application.Factory.Queries;
using GreenTunnel.Application.Workplace.Queries;
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
    public class GetAllWorkplacesQueryHandler : IRequestHandler<GetAllWorkplaceQuery, PagedList<WorkplaceViewModel>>
    {
        private readonly IFactoryRepository _factoryRepository;
        private readonly IMapper _mapper;
        private readonly IWorkplaceRepository _workplaceRepository;

        public GetAllWorkplacesQueryHandler(
            IFactoryRepository factoryRepository,
              IMapper mapper,
            IWorkplaceRepository workplaceRepository)
        {
            _mapper = mapper;
            _workplaceRepository = workplaceRepository;
        }
        public async Task<PagedList<WorkplaceViewModel>> Handle(GetAllWorkplaceQuery request, CancellationToken cancellationToken)
        {
            var workplacesList = await _workplaceRepository.GetWorkplacesAsync(request.SortColumn, request.SortOrder, request.SearchTerm, request.FactoryId, request.PageNumber, request.PageSize);

            var workplacesViewModels = _mapper.Map<List<WorkplaceViewModel>>(workplacesList.Items);

            var pagedList = new PagedList<WorkplaceViewModel>(
                 workplacesViewModels,
                 request.PageNumber,
                 request.PageSize,
                 workplacesList.TotalCount);

            return pagedList;
        }
    }
}
