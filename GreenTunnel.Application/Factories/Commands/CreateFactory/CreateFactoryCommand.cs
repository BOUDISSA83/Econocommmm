
using GreenTunnel.Infrastructure.ViewModels.Factories;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;

namespace GreenTunnel.Application.Factories.Commands.CreateFactory;

public class CreateFactoryCommand : IRequest<CqrsResponseViewModel>
{

    public CreateFactoryRequestViewModel Model { get; set; }
    public CreateFactoryCommand(CreateFactoryRequestViewModel model)
    {
        Model = model;
    }
}