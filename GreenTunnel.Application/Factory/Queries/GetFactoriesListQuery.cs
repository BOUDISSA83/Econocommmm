using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Factory.Queries
{
    public class GetFactoriesListQuery:IRequest<List<GetFacoriesListResponseModel>>
    {
    }
}
