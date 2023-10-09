
using GreenTunnel.Application.TestType.Commands.CreateTestType;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.TestType;

using MediatR;

namespace GreenTunnel.Application.TestType.Handler.Commands
{
    public class CreateTestTypeCommandHandler : IRequestHandler<CreateTestTypeCommand, CqrsResponseViewModel>
    {

   
      
        private readonly ITestTypeRepository _TestTypeRepository;
  

        public CreateTestTypeCommandHandler(ITestTypeRepository testTypeRepository)
        {               
            _TestTypeRepository = testTypeRepository;
        }


        public async Task<CqrsResponseViewModel> Handle(CreateTestTypeCommand request, CancellationToken cancellationToken)
        {
            var TestTypeModel = new GreenTunnel.Core.Entities.TestType
            {
                Name = request.Model.Name,
                Description = request.Model.Description,
                UpdatedDate = DateTime.UtcNow,
                CreatedBy = "",
                UpdatedBy = ""

            };

            var testTypeResult = await _TestTypeRepository.AddAsync(TestTypeModel);
            return new CreateTestTypeCommandResponseModel
            {
                TestTypeId = TestTypeModel.Id
            };
        }
    }
}

