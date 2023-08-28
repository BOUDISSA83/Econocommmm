using GreenTunnel.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels
{
    public class FactoryRequestViewModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Logo { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string Support { get; set; }
        public string UserId { get; set; }
        public List<int> WorkplaceIds { get; set; }
    }
}
