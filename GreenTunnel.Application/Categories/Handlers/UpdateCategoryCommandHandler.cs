using AutoMapper;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using GreenTunnel.Infrastructure.ViewModels.Response.Category;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenTunnel.Application.Categories.Commands.UpdateInputType;

namespace GreenTunnel.Application.Categories.Handlers
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CqrsResponseViewModel>
    {
        private readonly ICategoryRepository _categoryRepository;

        public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository
           )
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CqrsResponseViewModel> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetSingleOrDefaultAsync(f => f.Id == request.Model.Id);
            if (category == null)
            {
                return null;
            }
            category.UpdatedDate = DateTime.UtcNow;
            category.Name = request.Model.Name;
            category.MouldTypeId = request.Model.MouldTypeId;
            _categoryRepository.Update(category);
            return new UpdateCategoryCommandResponseModel
            {
                CategoryId = request.Model.Id,
            };
        }
    }
}
