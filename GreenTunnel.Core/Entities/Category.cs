using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Core.Entities
{
    public class Category: AuditableEntity
    {
        public Category()
        {
            Descriptions = new List<Description>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int MouldTypeId { get; set; }
        public int Order { get; set; }
        public virtual ICollection<Description> Descriptions { get; set; }
    }
}
