using GreenTunnel.Infrastructure.ViewModels.Factories;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;

namespace GreenTunnel.Application.Factories.Commands.UpdateFactory;

public class UpdateFactoryCommand : IRequest<CqrsResponseViewModel>
{
    public UpdateFactoryRequestViewModel Model { get; set; }
}