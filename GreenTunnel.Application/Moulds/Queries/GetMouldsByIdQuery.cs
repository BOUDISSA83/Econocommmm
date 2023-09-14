using GreenTunnel.Infrastructure.ViewModels;
using MediatR;

namespace GreenTunnel.Application.Moulds.Queries
{
    public class GetMouldsByIdQuery :IRequest<MouldsViewModel>
    {
        public int Id { get; set; }
    }
}
