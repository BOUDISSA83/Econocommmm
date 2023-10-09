using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Response.Test
{
    public class UpdateTestRequestViewModel
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public int TestTypeId { get; set; }

        public string UserId { get; set; }
        public string UpdatedBy { get; set; }
    }
}
