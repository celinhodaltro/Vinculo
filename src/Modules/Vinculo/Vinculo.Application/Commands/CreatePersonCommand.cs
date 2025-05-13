using MediatR;

namespace Vinculo.Application.Commands
{
    public class CreatePersonCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public string Cpf { get; set; }
        public int Age { get; set; }
    }
}
