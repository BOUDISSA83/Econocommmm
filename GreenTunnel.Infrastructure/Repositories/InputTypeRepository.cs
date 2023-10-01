using GreenTunnel.Core.Entities;
using GreenTunnel.Core.Interfaces;
using GreenTunnel.Infrastructure.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.Repositories
{
    public class InputTypeRepository:Repository<InputType>, IInputTypeRepository
    {
        private ApplicationDbContext _appContext => (ApplicationDbContext)_context;
        public InputTypeRepository(ApplicationDbContext context):base(context) { }
        

        public async Task<InputType> AddAsync(InputType inputType)
        {
            _appContext.InputTypes.Add(inputType);
            await _appContext.SaveChangesAsync();
            return inputType;
        }

        public async Task<List<InputType>> GetAllAsync()
        {
            IQueryable<InputType> inputTypes = _appContext.InputTypes
                .AsSingleQuery()
                .OrderBy(r => r.CreatedDate);
            var inputTypesList = await inputTypes.ToListAsync();

            return inputTypesList;
        }
        private static Expression<Func<InputType, object>> GetSortProperty(string sortColumn)
        {
            return sortColumn?.ToLower() switch
            {
                "name" => inputType => inputType.Name,
                _ => inputType => inputType.Id,
            };
        }
        public async Task<PagedList<InputType>> GetAllInputTypesAsync(string sortColumn, string sortOrder, string searchTerm, int page, int pageSize)
        {
            IQueryable<InputType> inputTypesQuery = _appContext.InputTypes;
            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                inputTypesQuery = inputTypesQuery.Where(p => p.Name.Contains(searchTerm));
            }

            if (sortOrder?.ToLower() == "desc")
            {
                inputTypesQuery = inputTypesQuery.OrderByDescending(GetSortProperty(sortColumn));
            }
            else
            {
                inputTypesQuery = inputTypesQuery.OrderBy(GetSortProperty(sortColumn));
            }

            var factories = inputTypesQuery
               .AsSingleQuery()
               .OrderBy(r => r.CreatedDate);


            var inputTypesListResponsesQuery = factories;
            var factoriesResult = await PagedList<InputType>.CreateAsync(inputTypesListResponsesQuery, page, pageSize);

            return factoriesResult;
        }
    }
}
