using MediatR;

namespace GreenTunnel.Application.Workplaces.Queries;

public class GetDuplicateWorkplaceQuery : IRequest<bool>
{
    public string Name { get; set; }
    public int WorkplaceId { get; set; }
}