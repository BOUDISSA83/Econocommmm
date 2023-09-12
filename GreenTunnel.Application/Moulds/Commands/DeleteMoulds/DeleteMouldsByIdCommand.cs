using MediatR;

namespace GreenTunnel.Application.Moulds.Commands.DeleteMoulds
{
    public class DeleteMouldsByIdCommand : IRequest<bool>
    {
        public int id { get; set; }

        public DeleteMouldsByIdCommand(int id) => this.id = id;
    }
}
