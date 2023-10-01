using System.ComponentModel.DataAnnotations.Schema;

namespace GreenTunnel.Core.Entities;

public class Workspace : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public int WorkplaceId { get; set; }
    [ForeignKey("WorkplaceId")]
    public virtual Workplace Workplace { get; set; }
    public string UserId { get; set; }
}