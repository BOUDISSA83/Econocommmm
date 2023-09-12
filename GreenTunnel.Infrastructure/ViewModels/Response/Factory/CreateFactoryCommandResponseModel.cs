using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.Factory
{
    public class CreateFactoryCommandResponseModel : CqrsResponseViewModel
    {
        public int FactoryId { get; set; }
    }
}
