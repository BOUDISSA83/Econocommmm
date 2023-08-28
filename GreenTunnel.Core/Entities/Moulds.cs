using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Core.Entities
{
    public class Moulds: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int PlacementId { get; set; }
        public List<string> Descriptions { get; set; }
        public int UserId { get; set; }
    }
}
