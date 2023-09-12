using GreenTunnel.Infrastructure.ViewModels;
using GreenTunnel.Infrastructure.ViewModels.Response;

using MediatR;

namespace GreenTunnel.Application.Moulds.Commands.CreateMoulds;

public class CreateMouldsCommand : IRequest<CqrsResponseViewModel>
{

    public MouldsViewModel Model { get; set; }
    public CreateMouldsCommand(MouldsViewModel model)
    {
        Model = model;
    }
}
