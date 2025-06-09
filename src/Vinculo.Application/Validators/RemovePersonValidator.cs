using FluentValidation;
using Vinculo.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinculo.Application.Validators
{
    public class RemovePersonValidator : AbstractValidator<RemovePersonCommand>
    {
        public RemovePersonValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("O Id é obrigatorio para identificar o objeto!");
        }
    }
}
