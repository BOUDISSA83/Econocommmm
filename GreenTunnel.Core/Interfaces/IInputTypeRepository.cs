using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Core.Interfaces
{
    public interface IInputTypeRepository:IRepository<InputType>
    {
        Task<InputType> AddAsync(InputType inputType);
        Task<List<InputType>> GetAllAsync();    
        Task<PagedList<InputType>> GetAllInputTypesAsync(string? sortColumn, string? sortOrder, string? searchTerm, int page, int pageSize);

    }
}
