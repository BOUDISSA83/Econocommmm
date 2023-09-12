using GreenTunnel.Infrastructure.ViewModels;

using MediatR;

namespace GreenTunnel.Application.Moulds.Commands.UpdateMoulds;

public class UpdateMouldsCommand : IRequest<bool>
{
    public MouldsViewModel _moulds { get; set; }

    public UpdateMouldsCommand(MouldsViewModel moulds) => _moulds = moulds;
}
