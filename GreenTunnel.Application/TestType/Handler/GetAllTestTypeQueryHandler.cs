using AutoMapper;

using GreenTunnel.Application.TestType.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels;

using MediatR;

namespace GreenTunnel.Application.TestType.Handler
{
    public class GetAllTestTypeQueryHandler : IRequestHandler<GetAllTestTypeQuery, PagedList<TestTypeViewModel>>
    {
        private readonly ITestTypeRepository _testTypeRepository;
        private readonly IMapper _mapper;
        //private readonly IWorkplaceRepository _workplaceRepository;

        public GetAllTestTypeQueryHandler(
            ITestTypeRepository testTypeRepository,
              IMapper mapper,
            IWorkplaceRepository workplaceRepository)
        {
            _testTypeRepository = testTypeRepository;
            _mapper = mapper;
            //_workplaceRepository = workplaceRepository;
        }
        public async Task<PagedList<TestTypeViewModel>> Handle(GetAllTestTypeQuery request, CancellationToken cancellationToken)
        {
            var testTypesList = await _testTypeRepository.GetTestTypesAsync(request.SortColumn, request.SortOrder, request.SearchTerm, request.PageNumber, request.PageSize);



            var testTypeViewModels = _mapper.Map<List<TestTypeViewModel>>(testTypesList.Items);
            var pagedList = new PagedList<TestTypeViewModel>(
               testTypeViewModels,
                request.PageNumber,
                request.PageSize,
                testTypesList.TotalCount);
            return pagedList;




        }
    }
}
