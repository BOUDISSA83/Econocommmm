using GreenTunnel.Application.Factory.Commands.CreateFactory;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Workplaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Factory.Commands.CreateWorkplace
{
    public class CreateWorkplaceCommand:IRequest<CqrsResponseViewModel>
    {
        public CreateWorkplaceRequestViewModel Model { get; set; }
        public CreateWorkplaceCommand(CreateWorkplaceRequestViewModel model)
        {
            Model = model;
        }
    }
}
