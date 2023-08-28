using GreenTunnel.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.User.Commands.ResetPassword
{
    public class ResetPasswordCommands: IRequest<(bool Succeeded, string[] Errors)>
    {
        public ApplicationUser  User { get; set; }
        public string NewPassword { get; set; }
    }
}
