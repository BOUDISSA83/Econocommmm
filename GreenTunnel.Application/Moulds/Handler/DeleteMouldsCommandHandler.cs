using AutoMapper;
using GreenTunnel.Application.Moulds.Commands.DeleteMoulds;
using GreenTunnel.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GreenTunnel.Application.Moulds.Handlers;

public class DeleteMouldsCommandHandler : IRequestHandler<DeleteMouldsByIdCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IMouldsRepository _mouldsRepository;
    public DeleteMouldsCommandHandler(IAuthorizationService authorizationService,
        IMapper mapper,
        IMouldsRepository mouldsRepository)
    {
        _mapper = mapper;
        _mouldsRepository = mouldsRepository;
    }
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