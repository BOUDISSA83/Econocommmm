using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GreenTunnel.Infrastructure.ViewModels.Response.Test;
using GreenTunnel.Infrastructure.ViewModels.Response.TestType;

using MediatR;

namespace GreenTunnel.Application.TestType.Queries
{
    public class GetTestTypesListQuery : IRequest<List<GetTestTypesListResponseModel>>
    {
    }
}
