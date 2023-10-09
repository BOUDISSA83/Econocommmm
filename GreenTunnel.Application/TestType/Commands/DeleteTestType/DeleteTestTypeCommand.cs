
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;

namespace GreenTunnel.Application.TestType.Commands.DeleteTestType
{
    public class DeleteTestTypeCommand : IRequest<CqrsResponseViewModel>
    {
        public int TestTypeId { get; set; }
    }
}
