using GreenTunnel.Infrastructure.ViewModels.Response.Factories;
using MediatR;

namespace GreenTunnel.Application.Factories.Queries;

public class GetFactoryQuery : IRequest<FactoryViewModel>
{
    public int FactoryId { get; set; }
}