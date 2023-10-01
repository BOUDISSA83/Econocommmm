using GreenTunnel.Application.InputTypes.Commands.DeleteCategory;
using GreenTunnel.Application.InputTypes.Commands.DeleteInputType;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Categories.Handlers
{
    internal class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, CqrsResponseViewModel>
    {
        private readonly ICategoryRepository  _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }
        public async Task<CqrsResponseViewModel> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetSingleOrDefaultAsync(f => f.Id == request.CategoryId);

            if (category == null)
            {
                return null;
            }

            _categoryRepository.Remove(category);

            return new CqrsResponseViewModel(); // Return an appropriate response
        }
    }
}
