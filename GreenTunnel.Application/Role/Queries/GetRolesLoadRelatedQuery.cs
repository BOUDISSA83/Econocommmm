using GreenTunnel.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Role.Queries
{
    public class GetRolesLoadRelatedQuery:IRequest<List<ApplicationRole>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
