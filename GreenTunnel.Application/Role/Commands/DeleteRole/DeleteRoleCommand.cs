using GreenTunnel.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Role.Commands.DeleteRole
{
    public class DeleteRoleCommand:IRequest<(bool Succeeded, string[] Errors)>
    {
        public ApplicationRole Role { get; set; }
    }
}
