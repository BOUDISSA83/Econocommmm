using GreenTunnel.Infrastructure.ViewModels.Description;
using GreenTunnel.Infrastructure.ViewModels.InputType;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Description.Commands.UpdateDescription
{
    public class UpdateDescriptionCommand:IRequest<CqrsResponseViewModel>
    {
        public UpdateDescriptionRequestViewModel Model { get; set; }
    }
}
