using GreenTunnel.Application.Factory.Commands.DeleteFactory;
using GreenTunnel.Core.Repositories.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;

using MediatR;

namespace GreenTunnel.Application.Factory.Handler;

public class DeleteFactoryCommandHandler : IRequestHandler<DeleteFactoryCommand, CqrsResponseViewModel>
{
    private readonly IFactoryRepository _factoryRepository;
    private readonly IWorkplaceRepository _workplaceRepository;

    public DeleteFactoryCommandHandler(IFactoryRepository factoryRepository, IWorkplaceRepository workplaceRepository)
    {
        _factoryRepository = factoryRepository;
        _workplaceRepository = workplaceRepository;
    }

    public async Task<CqrsResponseViewModel> Handle(DeleteFactoryCommand request, CancellationToken cancellationToken)
    {
        var factory = await _factoryRepository.GetSingleOrDefaultAsync(f => f.Id == request.FactoryId);

        if (factory == null)
        {
            return null;
        }

        _factoryRepository.Remove(factory);

        return new CqrsResponseViewModel(); // Return an appropriate response
    }
}
