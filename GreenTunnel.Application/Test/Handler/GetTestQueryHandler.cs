using AutoMapper;

using GreenTunnel.Application.Test.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels;

using MediatR;

namespace GreenTunnel.Application.Test.Handler
{
    public class GetTestQueryHandler : IRequestHandler<GetTestQuery,TestViewModel >
    {
        private readonly ITestRepository _testRepository;
        private readonly IMapper _mapper;


        public GetTestQueryHandler(ITestRepository testRepository,
    IMapper mapper)

        {
            _testRepository = testRepository;
            _mapper = mapper;
        }
        public async Task<TestViewModel> Handle(GetTestQuery request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetByIdDetailsAsync(request.TestId);
            if (test == null) { return null; }
            var testViewModel = _mapper.Map<TestViewModel>(test);
            return testViewModel;   
        }
    }
}
