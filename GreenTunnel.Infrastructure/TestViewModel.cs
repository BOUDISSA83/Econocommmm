using GreenTunnel.Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels
{
    public class TestViewModel
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        
        public int TestTypeId { get; set; }
        public int ProductId { get; set; }
        public int ComplianceId { get; set; }
        public string TestTypeName { get; set; }
    }
}
