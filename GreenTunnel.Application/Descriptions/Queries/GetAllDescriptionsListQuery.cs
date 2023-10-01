using GreenTunnel.Infrastructure.ViewModels.Response.Description;
using GreenTunnel.Infrastructure.ViewModels.Response.InputType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Descriptions.Queries
{
    public class GetAllDescriptionsListQuery:IRequest<List<GetDescriptionsListResponseModel>>
    {
    }
}
