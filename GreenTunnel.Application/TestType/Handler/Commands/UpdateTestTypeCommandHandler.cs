using GreenTunnel.Application.TestType.Commands.UpdateTestType;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;

using MediatR;

namespace GreenTunnel.Application.TestType.Handler.Commands
{
    public class UpdateTestTypeCommandHandler : IRequestHandler<UpdateTestTypeCommand, CqrsResponseViewModel>
    {


        private readonly ITestTypeRepository _testTypeRepository;

        public UpdateTestTypeCommandHandler(ITestTypeRepository testTypeRepository)
        {
            _testTypeRepository = testTypeRepository;
          
        }

        public async Task<CqrsResponseViewModel> Handle(UpdateTestTypeCommand request, CancellationToken cancellationToken)
        {
            var testType = await _testTypeRepository.GetSingleOrDefaultAsync(f => f.Id == request.Model.Id);

            if (testType == null)
            {
                return null;
            }

            testType.Name = request.Model.Name;
            testType.Description= request.Model.Description;    
            testType.UpdatedDate = DateTime.UtcNow;
            testType.UpdatedBy = request.Model.UserId; // Set the updated by user ID


            _testTypeRepository.Update(testType);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }
}
