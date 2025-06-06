﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vinculo.Application.Commands
{
    public class UpdatePersonCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
    }
}
