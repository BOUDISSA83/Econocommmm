using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenTunnel.Application.Factory.Commands.CreateFactory
{
    public class CreateFactoryCommandValidator :AbstractValidator<CreateFactoryCommand>
    {
        public CreateFactoryCommandValidator()
        {
            RuleFor(x => x.Model.Name).NotNull();
            RuleFor(x=>x.Model.WorkplaceIds).NotNull();
        }
    }
}
