﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.Test
{
    public class CreateTestCommandResponseModel : CqrsResponseViewModel
    {
        public int TestId { get; set; }
    }
}
