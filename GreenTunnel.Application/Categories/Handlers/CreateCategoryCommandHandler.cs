using GreenTunnel.Application.Categories.Commands.CreateCategory;
using GreenTunnel.Application.InputType.Commands.CreateInputType;
using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Repositories;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.Category;
using GreenTunnel.Infrastructure.ViewModels.Response.InputType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Categories.Handlers
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CqrsResponseViewModel>
    {
        private readonly ICategoryRepository  _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CqrsResponseViewModel> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var categoryModel = new Category()
            {
                Name = request.Model.Name,
                 CreatedDate = DateTime.UtcNow,
                  MouldTypeId =  1,
                   Order= request.Model.Order,

            };
            var inputTypeResult = _categoryRepository.AddAsync(categoryModel);
            return new CreateCategoryCommandResponseModel
            {
                 CategoryId = categoryModel.Id,
            };
        }
    }
}
