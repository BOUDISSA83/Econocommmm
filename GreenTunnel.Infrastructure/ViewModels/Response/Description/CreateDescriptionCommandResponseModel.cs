using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.Description
{
    public class CreateDescriptionCommandResponseModel: CqrsResponseViewModel
    {
        public int InputTypeId { get; set; }

    }
}
