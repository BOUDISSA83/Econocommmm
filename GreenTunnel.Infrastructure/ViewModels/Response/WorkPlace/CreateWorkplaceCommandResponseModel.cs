using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.WorkPlace
{
    public class CreateWorkplaceCommandResponseModel: CqrsResponseViewModel
    {
        public int WorkPlaceId { get; set; }

    }
}
