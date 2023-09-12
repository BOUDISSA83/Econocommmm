using GreenTunnel.Infrastructure.ViewModels.Factory;
using GreenTunnel.Infrastructure.ViewModels.Response;

using MediatR;

namespace GreenTunnel.Application.Factory.Commands.UpdateFactory;

public class UpdateFactoryCommand : IRequest<CqrsResponseViewModel>
{
    public UpdateFactoryRequestViewModel Model { get; set; }
}
