
using GreenTunnel.Application.TestType.Commands.DeleteTestType;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;

using MediatR;

namespace GreenTunnel.Application.TestType.Handler.Commands
{
    public class DeleteTestTypeCommandHandler : IRequestHandler<DeleteTestTypeCommand, CqrsResponseViewModel> 
    {

        private readonly ITestTypeRepository _testTypeRepository;
     

        public DeleteTestTypeCommandHandler(ITestTypeRepository testTypeRepository)
        {
            _testTypeRepository = testTypeRepository;
        
        }

        public async Task<CqrsResponseViewModel> Handle(DeleteTestTypeCommand request, CancellationToken cancellationToken)
        {
            var testType = await _testTypeRepository.GetSingleOrDefaultAsync(f => f.Id == request.TestTypeId);

            if (testType == null)
            {
                return null;
            }

            _testTypeRepository.Remove(testType);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }




    }
}
