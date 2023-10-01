namespace GreenTunnel.Infrastructure.ViewModels.Response.Factories;

public class CreateFactoryCommandResponseModel : CqrsResponseViewModel
{
    public int FactoryId { get; set; }
}