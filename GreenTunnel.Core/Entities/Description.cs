using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Core.Entities
{
    public class Description: AuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
       

        public int Order { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }
        [ForeignKey("InputTypeId")]

        public int InputTypeId { get; set; }
        public InputType EntityType { get; set; }
    }
}
