using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Moulds.Commands.DeleteMoulds
{
    public class DeleteMouldsByIdCommand : IRequest<bool>
    {
        public int id { get; set; }

        public DeleteMouldsByIdCommand(int id)
        {
           this.id = id;
        }
    }
}
