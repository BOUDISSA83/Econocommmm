using GreenTunnel.Infrastructure.ViewModels.InputType;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.InputType.Commands.CreateInputType
{
    public class CreateInputTypeCommand:IRequest<CqrsResponseViewModel>
    {
        public CreateInputTypeRequestViewModel Model { get; set; }
        public CreateInputTypeCommand(CreateInputTypeRequestViewModel model)
        {
            Model = model;
        }
    }
}
