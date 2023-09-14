using GreenTunnel.Infrastructure.ViewModels.Factory;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Factory.Commands.UpdateFactory
{
    public class UpdateFactoryCommand: IRequest<CqrsResponseViewModel>
    {
        public UpdateFactoryRequestViewModel Model { get; set; }
    }
}
