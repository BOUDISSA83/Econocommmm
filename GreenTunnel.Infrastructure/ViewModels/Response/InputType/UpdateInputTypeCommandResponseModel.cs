using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.InputType
{
    public class UpdateInputTypeCommandResponseModel: CqrsResponseViewModel
    {
        public int InputTypeId { get; set; }
    }
}
