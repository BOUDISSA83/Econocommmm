using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using GreenTunnel.Infrastructure.ViewModels.Response.WorkPlace;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workplaces.Queries
{
    public class GetWorkplacesListQuery : IRequest<List<GetWorkplacesListResponseModel>>
    {
    }
}
