using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Commands.DeleteWorkplace;

public class DeleteWorkplaceCommand : IRequest<CqrsResponseViewModel>
{
    public int WorkplaceId { get; set; }
}