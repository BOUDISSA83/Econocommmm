using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTunnel.Core.Entities;

public class Moulds : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public int WorkspaceId { get; set; }
    public string UserId { get; set; }
    [ForeignKey("WorkspaceId")]
    public virtual Workspace Workspace { get; set; }
}