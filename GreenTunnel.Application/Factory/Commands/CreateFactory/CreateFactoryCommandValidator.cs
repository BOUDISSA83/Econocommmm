using FluentValidation;

namespace GreenTunnel.Application.Factory.Commands.CreateFactory;

public class CreateFactoryCommandValidator : AbstractValidator<CreateFactoryCommand>
{
    public CreateFactoryCommandValidator()
    {
        RuleFor(x => x.Model.Name).NotNull();
        RuleFor(x => x.Model.WorkplaceIds).NotNull();
    }
}
