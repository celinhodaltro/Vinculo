using FluentValidation;
using Person.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Validators
{
    public class CreatePersonValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Cpf).Length(11);
        }
    }
}
