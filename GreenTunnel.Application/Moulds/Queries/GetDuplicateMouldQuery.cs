using MediatR;

namespace GreenTunnel.Application.Moulds.Queries;

public class GetDuplicateMouldQuery : IRequest<bool>
{
    public string Name { get; set; }
}