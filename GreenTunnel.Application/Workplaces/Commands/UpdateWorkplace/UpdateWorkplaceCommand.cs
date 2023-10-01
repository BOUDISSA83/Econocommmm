using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Workplaces;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Commands.UpdateWorkplace;

public class UpdateWorkplaceCommand : IRequest<CqrsResponseViewModel>
{
    public UpdateWorkplaceRequestViewModel Model { get; set; }
}