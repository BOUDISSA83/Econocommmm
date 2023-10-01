using AutoMapper;
using GreenTunnel.Application.Moulds.Commands.UpdateMoulds;
using GreenTunnel.Core.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Authorization;

namespace GreenTunnel.Application.Moulds.Handlers.Commands;

public class UpdateMouldsCommandHandler : IRequestHandler<UpdateMouldsCommand, bool>
{
    private readonly IMapper _mapper;
    private readonly IMouldsRepository _mouldsRepository;
    public UpdateMouldsCommandHandler(IAuthorizationService authorizationService,
        IMapper mapper,
        IMouldsRepository mouldsRepository)
    {
        _mapper = mapper;
        _mouldsRepository = mouldsRepository;
    }
    public async Task<bool> Handle(UpdateMouldsCommand request, CancellationToken cancellationToken)
    {
        try
        {
            _mouldsRepository.Update(_mapper.Map<GreenTunnel.Core.Entities.Moulds>(request._moulds));
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}