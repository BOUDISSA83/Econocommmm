using GreenTunnel.Infrastructure.ViewModels.Factory;
using GreenTunnel.Infrastructure.ViewModels.Response;

using MediatR;

namespace GreenTunnel.Application.Factory.Commands.CreateFactory;

public class CreateFactoryCommand : IRequest<CqrsResponseViewModel>
{
    public CreateFactoryRequestViewModel Model { get; set; }

    public CreateFactoryCommand(CreateFactoryRequestViewModel model)
    {
        Model = model;
    }
}
