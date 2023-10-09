
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;

namespace GreenTunnel.Application.Test.Commands.DeleteTest
{
    public class DeleteTestCommand : IRequest<CqrsResponseViewModel>
    {
        public int TestId { get; set; }
    }
}
