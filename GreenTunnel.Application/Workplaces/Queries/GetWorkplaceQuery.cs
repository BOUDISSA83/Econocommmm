using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;

namespace GreenTunnel.Application.Workplaces.Queries;

public class GetWorkplaceQuery : IRequest<WorkplaceViewModel>
{
    public int WorkplaceId { get; set; }
}