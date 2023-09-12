using GreenTunnel.Application.Moulds.Commands.DeleteMoulds;
using GreenTunnel.Core.Repositories.Interfaces;

using MediatR;

namespace GreenTunnel.Application.Moulds.Handlers.Commands;

public class DeleteMouldsCommandHandler : IRequestHandler<DeleteMouldsByIdCommand, bool>
{
    private readonly IMouldsRepository _mouldsRepository;

    public DeleteMouldsCommandHandler(IMouldsRepository mouldsRepository) => _mouldsRepository = mouldsRepository;

    public async Task<bool> Handle(DeleteMouldsByIdCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _mouldsRepository.Remove(_mouldsRepository.Get(request.id));
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}
