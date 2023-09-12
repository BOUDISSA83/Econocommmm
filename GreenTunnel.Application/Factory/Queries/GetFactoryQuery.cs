using GreenTunnel.Infrastructure.ViewModels.Response.Factory;

using MediatR;

namespace GreenTunnel.Application.Factory.Queries;

public class GetFactoryQuery : IRequest<FactoryViewModel>
{
    public int FactoryId { get; set; }
}
