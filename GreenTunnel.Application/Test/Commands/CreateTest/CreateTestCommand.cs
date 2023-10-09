
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;

namespace GreenTunnel.Application.Test.Commands.CreateTest
{
    public class CreateTestCommand : IRequest<CqrsResponseViewModel>
    {

        public TestViewModel model { get; set; }


        public CreateTestCommand(TestViewModel model)
        {
            this.model = model;
        }
    }
}
