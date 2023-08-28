using GreenTunnel.Core.Entities;
using GreenTunnel.Infrastructure.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Role.Commands.CreateRole
{
    public class CreateRoleCommand:IRequest<(bool Succeeded, string[] Errors)>
    {
        public ApplicationRole Role { get; set; }
        public RoleViewModel RoleView { get; set; }
        public CreateRoleCommand(ApplicationRole role, RoleViewModel roleView)
        {
            Role = role;
            RoleView = roleView;
        }
    }
}
