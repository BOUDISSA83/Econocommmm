using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.Helpers;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Role.Queries
{
    public class GetRolesLoadRelatedQuery:IRequest<PagedList<ApplicationRole>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
    }
}
