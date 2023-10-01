using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Description.Commands.DeleteDescription
{
    public class DeleteDescriptionCommand:IRequest<CqrsResponseViewModel>
    {
        public int InputTypeId { get; set; }

    }
}
