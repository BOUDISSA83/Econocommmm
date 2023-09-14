using GreenTunnel.Application.Factory.Commands.CreateWorkplace;
using GreenTunnel.Infrastructure.ViewModels;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Moulds.Commands.CreateMoulds
{
    public class CreateMouldsCommand : IRequest<CqrsResponseViewModel>
    {

        public MouldsViewModel Model { get; set; }
        public CreateMouldsCommand(MouldsViewModel model)
        {
            Model = model;
        }
    }

}
