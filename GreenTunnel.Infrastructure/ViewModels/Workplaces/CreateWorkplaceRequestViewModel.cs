using System.ComponentModel.DataAnnotations;

namespace GreenTunnel.Infrastructure.ViewModels.Workplaces;

public class CreateWorkplaceRequestViewModel
{
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Description { get; set; }
    public int Order { get; set; }
    public string UserId { get; set; }
    public string CreatedBy { get; set; }
    public int FactoryId { get; set; }

}