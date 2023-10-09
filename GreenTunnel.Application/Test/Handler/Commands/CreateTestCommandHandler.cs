
using GreenTunnel.Application.Test.Commands.CreateTest;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.Test;

using MediatR;

namespace GreenTunnel.Application.Test.Handler.Commands
{
    public class CreateTestTypeCommandHandler : IRequestHandler<CreateTestCommand, CqrsResponseViewModel>
    {

        private readonly ITestRepository _testRepository;
        private readonly IComplianceRepository _complianceRepository;
        private readonly ITestTypeRepository _TestTypeRepository;

        public CreateTestTypeCommandHandler(ITestRepository testRepository, IComplianceRepository complianceRepository, ITestTypeRepository testTypeRepository)
        {
            _testRepository = testRepository;
            _complianceRepository = complianceRepository;
            _TestTypeRepository = testTypeRepository;
        }


        public async Task<CqrsResponseViewModel> Handle(CreateTestCommand request, CancellationToken cancellationToken)
        {
            var TestModel = new GreenTunnel.Core.Entities.Test
            {
                Name = request.model.Name,
                Description =request.model.Description,
                UpdatedDate = DateTime.UtcNow,
                CreatedBy = "",
                UpdatedBy = ""

            };


            var Compliance = await _complianceRepository.GetByIdAsync(request.model.ComplianceId);
            if (Compliance != null)
            {
                TestModel.Compliance = Compliance;
            }

            var testType = await _TestTypeRepository.GetByIdAsync(request.model.TestTypeId);

            if (testType != null)
            {
                TestModel.TestType = testType;
            }


            var factoryResult = await _testRepository.AddAsync(TestModel);
            return new CreateTestCommandResponseModel
            {
                TestId = TestModel.Id
            };
        }
    }
}

