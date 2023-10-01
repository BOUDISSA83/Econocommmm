using MediatR;

namespace GreenTunnel.Application.Factories.Queries;

public class GetDuplicateFactoryQuery : IRequest<bool>
{
    public string Name { get; set; }
    public int FactoryId { get; set; }
}