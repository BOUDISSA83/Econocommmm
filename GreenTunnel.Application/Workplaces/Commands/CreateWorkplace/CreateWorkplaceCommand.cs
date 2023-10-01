using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Workplaces;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Commands.CreateWorkplace;

public class CreateWorkplaceCommand : IRequest<CqrsResponseViewModel>
{
    public CreateWorkplaceRequestViewModel Model { get; }
    public CreateWorkplaceCommand(CreateWorkplaceRequestViewModel model)
    {
        Model = model;
    }
}