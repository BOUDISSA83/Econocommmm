using GreenTunnel.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.User.Queries
{
    public class CheckPasswordQuery :IRequest<bool>
    {
        public ApplicationUser User { get; set; }
        public string CurrentPassword { get; set; }
    }
}
