using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.TestType
{
    public class CreateTestTypeCommandResponseModel : CqrsResponseViewModel
    {
        public int TestTypeId { get; set; }
    }
}
