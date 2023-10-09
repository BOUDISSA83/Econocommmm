using AutoMapper;

using GreenTunnel.Application.TestType.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels;

using MediatR;

namespace GreenTunnel.Application.TestType.Handler
{
    public class GetTestQueryHandler : IRequestHandler<GetTestTypeQuery,TestTypeViewModel >
    {
        private readonly ITestTypeRepository _testTypeRepository;
        private readonly IMapper _mapper;


        public GetTestQueryHandler(ITestTypeRepository testTypeRepository,
    IMapper mapper)

        {
            _testTypeRepository = testTypeRepository;
            _mapper = mapper;
        }
        public async Task<TestTypeViewModel> Handle(GetTestTypeQuery request, CancellationToken cancellationToken)
        {
            var testType = await _testTypeRepository.GetSingleOrDefaultAsync(p => p.Id == request.TestTypeId);
            if (testType == null) { return null; }
            var testTypeViewModel = _mapper.Map<TestTypeViewModel>(testType);
            return testTypeViewModel;   
        }
    }
}
