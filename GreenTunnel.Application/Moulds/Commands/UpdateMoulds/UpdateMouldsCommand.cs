using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Moulds.Commands.UpdateMoulds
{
    public class UpdateMouldsCommand : IRequest<bool>
    {
        public MouldsViewModel _moulds { get; set; }

        public UpdateMouldsCommand(MouldsViewModel moulds)
        {
            _moulds = moulds;
        }
    }
}
