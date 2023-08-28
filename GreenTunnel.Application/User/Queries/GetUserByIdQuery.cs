using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.CQRS.Queries
{
    public class GetUserByIdQuery:IRequest<UserViewModel>
    {
        public string Id { get; set; }
        public ClaimsPrincipal User { get; set; }
    }
}
