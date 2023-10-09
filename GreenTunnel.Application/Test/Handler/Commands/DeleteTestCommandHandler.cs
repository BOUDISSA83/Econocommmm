
using GreenTunnel.Application.Test.Commands.DeleteTest;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;

using MediatR;

namespace GreenTunnel.Application.Test.Handler.Commands
{
    public class DeleteTestCommandHandler : IRequestHandler<DeleteTestCommand, CqrsResponseViewModel>
    {

        private readonly ITestRepository _testRepository;


        public DeleteTestCommandHandler(ITestRepository testRepository)
        {
            _testRepository = testRepository;

        }

        public async Task<CqrsResponseViewModel> Handle(DeleteTestCommand request, CancellationToken cancellationToken)
        {
            var test = await _testRepository.GetSingleOrDefaultAsync(f => f.Id == request.TestId);

            if (test == null)
            {
                return null;
            }

            _testRepository.Remove(test);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }
}
