using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Factory.Commands.DeleteFactory
{
    public class DeleteFactoryCommand : IRequest<CqrsResponseViewModel>
    {
        public int FactoryId { get; set; }
    }

}
