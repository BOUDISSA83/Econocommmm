using GreenTunnel.Infrastructure.ViewModels.Response;

using MediatR;

namespace GreenTunnel.Application.Factory.Commands.DeleteFactory;

public class DeleteFactoryCommand : IRequest<CqrsResponseViewModel>
{
    public int FactoryId { get; set; }
}
