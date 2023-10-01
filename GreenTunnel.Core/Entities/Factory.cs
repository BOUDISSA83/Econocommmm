namespace GreenTunnel.Core.Entities;

public class Factory : AuditableEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Address { get; set; }
    public string Logo { get; set; }
    public string Phone { get; set; }
    public string Mobile { get; set; }
    public string Email { get; set; }
    public string Support { get; set; }
    public virtual ICollection<Workplace> Workplaces { get; set; }
    public string UserId { get; set; }
    public Factory()
    {
        Workplaces = new List<Workplace>();
    }
}