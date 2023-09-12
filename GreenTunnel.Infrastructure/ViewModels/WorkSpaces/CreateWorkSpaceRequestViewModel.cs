using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels.Workplaces
{
    public class CreateWorkSpaceRequestViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Order { get; set; }
        public string UserId { get; set; }
        public string CreatedBy { get; set; }
        public int WorkplaceId { get; set; }

    }
}
