using GreenTunnel.Application.Factory.Commands.CreateWorkplace;
using GreenTunnel.Infrastructure.ViewModels;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Factory.Commands.CreateFactory
{
    public class CreateFactoryCommand:IRequest<CqrsResponseViewModel>
    {

        public FactoryRequestViewModel Model { get; set; }
        public CreateFactoryCommand(FactoryRequestViewModel model)
        {
            Model = model;
        }
    }

}
