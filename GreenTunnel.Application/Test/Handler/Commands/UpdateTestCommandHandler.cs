
using GreenTunnel.Application.Test.Commands.UpdateTest;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;

using MediatR;

namespace GreenTunnel.Application.Test.Handler.Commands
{
    public class UpdateTestCommandHandler : IRequestHandler<UpdateTestCommand, CqrsResponseViewModel>
    {


        private readonly ITestRepository _testRepository;
        private readonly ITestTypeRepository _testTypeRepository;

        public UpdateTestCommandHandler(ITestRepository testRepository, ITestTypeRepository testTypeRepository)
        {
            _testRepository = testRepository;
            _testTypeRepository = testTypeRepository;

        }

        public async Task<CqrsResponseViewModel> Handle(UpdateTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetSingleOrDefaultAsync(f => f.Id == request.Model.Id);

            if (test == null)
            {
                return null;
            }

            test.Name = request.Model.Name;
            test.Description = request.Model.Description;
            test.UpdatedDate = DateTime.UtcNow;
            test.UpdatedBy = request.Model.UserId; // Set the updated by user ID
            test.TestType = _testTypeRepository.GetByIdAsync(request.Model.TestTypeId).Result;


                


            _testRepository.Update(test);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }
}
