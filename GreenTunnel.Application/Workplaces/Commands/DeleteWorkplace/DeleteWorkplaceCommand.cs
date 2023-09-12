using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workplace.Commands.DeleteWorkplace
{
    public class DeleteWorkplaceCommand : IRequest<CqrsResponseViewModel>
    {
        public int WorkplaceId { get; set; }
    }
}
