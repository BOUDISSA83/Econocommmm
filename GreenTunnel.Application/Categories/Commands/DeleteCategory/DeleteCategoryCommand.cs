using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.InputTypes.Commands.DeleteCategory
{
    public class DeleteCategoryCommand : IRequest<CqrsResponseViewModel>
    {
        public int CategoryId { get; set; }

    }
}
