using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.WorkSpace
{
    public class CreateWorkSpaceCommandResponseModel: CqrsResponseViewModel
    {
        public int WorkSpaceId { get; set; }

    }
}
