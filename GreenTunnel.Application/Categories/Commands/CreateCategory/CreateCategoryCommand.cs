using GreenTunnel.Infrastructure.ViewModels.Category;
using GreenTunnel.Infrastructure.ViewModels.InputType;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand:IRequest<CqrsResponseViewModel>
    {
        public CreateICategoryRequestViewModel Model { get; set; }
        public CreateCategoryCommand(CreateICategoryRequestViewModel model)
        {
            Model = model;
        }
    }
}
