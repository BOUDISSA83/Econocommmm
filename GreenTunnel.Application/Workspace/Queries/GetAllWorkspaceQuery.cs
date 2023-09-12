using GreenTunnel.Infrastructure.Helpers;
using GreenTunnel.Infrastructure.ViewModels.Response.Factory;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Workspace.Queries
{
    public class GetAllWorkspaceQuery : IRequest<PagedList<WorkSpaceViewModel>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? SearchTerm { get; set; }
        public string? SortColumn { get; set; }
        public string? SortOrder { get; set; }
        public int? WorkplaceId { get; set; }
    }
}