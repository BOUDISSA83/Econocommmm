using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GreenTunnel.Infrastructure.ViewModels;

using MediatR;

namespace GreenTunnel.Application.TestType.Queries
{
    public class GetTestTypeQuery : IRequest<TestTypeViewModel>
    {
        public int TestTypeId { get; set; }
    }
}
