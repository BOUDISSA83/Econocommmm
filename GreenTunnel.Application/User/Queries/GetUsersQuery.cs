using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.CQRS.Queries
{
    public class GetUsersQuery:IRequest<List<UserViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
