﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.Category
{
    public class CreateCategoryCommandResponseModel: CqrsResponseViewModel
    {
        public int CategoryId { get; set; }

    }
}
