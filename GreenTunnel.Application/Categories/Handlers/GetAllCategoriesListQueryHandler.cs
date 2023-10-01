using AutoMapper;
using GreenTunnel.Application.Categories.Queries;
using GreenTunnel.Application.InputTypes.Queries;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.ViewModels.Response.Category;
using GreenTunnel.Infrastructure.ViewModels.Response.InputType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Categories.Handlers
{
    public class GetAllCategoriesListQueryHandler:IRequestHandler<GetAllCatgoriesListQuery, List<GetCategoriesListResponseModel>>
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public GetAllCategoriesListQueryHandler(ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<List<GetCategoriesListResponseModel>> Handle(GetAllCatgoriesListQuery request, CancellationToken cancellationToken)
        {
            var categoriesList = await _categoryRepository.GetAllAsync();
            var categoriesViewModel = _mapper.Map<List<GetCategoriesListResponseModel>>(categoriesList);
            return categoriesViewModel;
        }
    }
}
