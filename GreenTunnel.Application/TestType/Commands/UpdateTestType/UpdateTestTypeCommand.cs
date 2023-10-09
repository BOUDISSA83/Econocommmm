using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.TestType;

using MediatR;

namespace GreenTunnel.Application.TestType.Commands.UpdateTestType
{
    public class UpdateTestTypeCommand : IRequest<CqrsResponseViewModel>
    {
        public UpdateTestTypeRequestViewModel Model { get; set; }
    }
    

    
}
