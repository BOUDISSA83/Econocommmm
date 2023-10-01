using GreenTunnel.Infrastructure.ViewModels.Description;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Description.Commands
{
    public class CreateDescriptionCommand : IRequest<CqrsResponseViewModel>
    {
        public CreateDescriptionRequestViewModel Model { get; set; }
        public CreateDescriptionCommand(CreateDescriptionRequestViewModel model)
        {
            Model = model;
        }
    }
}
