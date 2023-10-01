using GreenTunnel.Infrastructure.ViewModels.Response.Category;
using GreenTunnel.Infrastructure.ViewModels.Response.InputType;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Categories.Queries
{
    public class GetAllCatgoriesListQuery:IRequest<List<GetCategoriesListResponseModel>>
    {
    }
}
