using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using GreenTunnel.Infrastructure.ViewModels.Response.TestType;

namespace GreenTunnel.Application.TestType.Commands.CreateTestType
{
    public class CreateTestTypeCommand : IRequest<CqrsResponseViewModel>
    {
        public CreateTestTypeRequestViewModel Model { get; set; }
        public CreateTestTypeCommand(CreateTestTypeRequestViewModel model)
        {
            this.Model = model;
        }
    }
}
