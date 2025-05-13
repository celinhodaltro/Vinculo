using FluentValidation;
using Vinculo.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinculo.Application.Validators
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .WithMessage("O nome é obrigatório.");

            RuleFor(x => x.Cpf)
                .Length(11)
                .WithMessage("O CPF deve ter exatamente 11 dígitos.");
        }
    }
}
