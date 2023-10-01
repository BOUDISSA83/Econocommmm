using System.ComponentModel.DataAnnotations;

namespace GreenTunnel.Infrastructure.ViewModels.Workspaces;

public class UpdateWorkSpaceRequestViewModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public string UserId { get; set; }
    public string UpdatedBy { get; set; }
    public int WorkplaceId { get; set; }
}