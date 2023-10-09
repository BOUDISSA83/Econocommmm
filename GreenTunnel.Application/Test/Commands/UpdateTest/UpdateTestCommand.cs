using GreenTunnel.Infrastructure.ViewModels.Response.Test;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;

namespace GreenTunnel.Application.Test.Commands.UpdateTest
{
    public class UpdateTestCommand : IRequest<CqrsResponseViewModel>
    {
        public UpdateTestRequestViewModel Model { get; set; }
    }
}
