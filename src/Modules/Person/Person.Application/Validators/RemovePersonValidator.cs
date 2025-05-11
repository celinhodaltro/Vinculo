using FluentValidation;
using Person.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person.Application.Validators
{
    public class RemovePersonValidator : AbstractValidator<RemovePersonCommand>
    {
        public RemovePersonValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
}
