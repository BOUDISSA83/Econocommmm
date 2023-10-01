using GreenTunnel.Infrastructure.ViewModels.InputType;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.InputTypes.Commands.UpdateInputType
{
    public class UpdateInputTypeCommand:IRequest<CqrsResponseViewModel>
    {
        public UpdateInputTypeRequestViewModel Model { get; set; }
    }
}
