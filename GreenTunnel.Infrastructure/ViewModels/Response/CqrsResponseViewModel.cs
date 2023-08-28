using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response
{
    public class CqrsResponseViewModel
    {
        [JsonProperty("statusCode")]
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
        [JsonProperty("errorMessage")]
        public string ErrorMessage { get; set; }
    }
}
