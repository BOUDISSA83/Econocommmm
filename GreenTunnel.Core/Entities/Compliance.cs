using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Core.Entities
{
    public class Compliance : AuditableEntity
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string status { get; set; }

    }
}
