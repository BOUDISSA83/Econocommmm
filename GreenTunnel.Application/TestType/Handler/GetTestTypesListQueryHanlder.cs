using AutoMapper;

using GreenTunnel.Application.TestType.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.TestType;

using MediatR;

namespace GreenTunnel.Application.TestType.Handler
{
    public class GetTestTypesListQueryHanlder : IRequestHandler<GetTestTypesListQuery, List<GetTestTypesListResponseModel>>
    {
        private readonly ITestTypeRepository _tesTypeRepository;
        private readonly IMapper _mapper;

        public GetTestTypesListQueryHanlder(ITestTypeRepository testTypeRepository,
            IMapper mapper)

        {
            _tesTypeRepository = testTypeRepository;
            _mapper = mapper;
        }
        public async Task<List<GetTestTypesListResponseModel>> Handle(GetTestTypesListQuery request, CancellationToken cancellationToken)
        {
            var tesTypesList = await _tesTypeRepository.GetAllTestTypes();
            var testTypesViewModel = _mapper.Map<List<GetTestTypesListResponseModel>>(tesTypesList);
            return testTypesViewModel;
        }
    }
}
