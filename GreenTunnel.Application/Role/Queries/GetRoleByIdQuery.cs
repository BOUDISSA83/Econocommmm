using GreenTunnel.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Role.Queries
{
    public class GetRoleByIdQuery:IRequest<ApplicationRole>
    {
        public string RoleId { get; set; }
    }
}
