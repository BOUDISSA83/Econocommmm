using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTunnel.Core.Entities;

public class Workplace: AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public virtual ICollection<Workspace> Workspaces { get; set; }
    public int FactoryId { get; set; }
    [ForeignKey("FactoryId")]
    public virtual Factory Factory { get; set; }
    public string UserId { get; set; }
}
