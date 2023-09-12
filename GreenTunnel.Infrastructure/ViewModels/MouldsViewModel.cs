using GreenTunnel.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Infrastructure.ViewModels
{
    public class MouldsViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int WorkspaceId { get; set; }
        public string UserId { get; set; }
        //public virtual Workspace Workspace { get; set; }
        //public List<string> Description { get; set; }
    }
}
