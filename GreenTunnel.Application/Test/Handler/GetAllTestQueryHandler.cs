using AutoMapper;


using GreenTunnel.Application.Test.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels;

using MediatR;

namespace GreenTunnel.Application.Test.Handler
{
    public class GetAllTestQueryHandler : IRequestHandler<GetAllTestQuery, PagedList<TestViewModel>>
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;
        //private readonly IWorkplaceRepository _workplaceRepository;

        public GetAllTestQueryHandler(
            ITestRepository testRepository,
              IMapper mapper,
            IWorkplaceRepository workplaceRepository)
        {
            _testRepository = testRepository;
            _mapper = mapper;
         //_workplaceRepository = workplaceRepository;
        }
        public async Task<PagedList<TestViewModel>> Handle(GetAllTestQuery request, CancellationToken cancellationToken)
        {
            var testsList = await _testRepository.GetTestsAsync(request.SortColumn, request.SortOrder, request.SearchTerm, request.PageNumber, request.PageSize);

            var testViewModels = _mapper.Map<List<TestViewModel>>(testsList.Items);

            var pagedList = new PagedList<TestViewModel>(
                testViewModels,
                request.PageNumber,
                request.PageSize,
                testsList.TotalCount);
            return pagedList;


        }
    }
}
