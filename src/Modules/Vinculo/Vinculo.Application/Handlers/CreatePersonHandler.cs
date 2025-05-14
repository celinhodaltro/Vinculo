using MediatR;
using Vinculo.Application.Commands;
using Vinculo.Domain.Entities;
using Vinculo.Domain.Interfaces;
using Vinculo.Domain.ValueObjects;

namespace Vinculo.Application.Handlers
{
    public class CreatePersonHandler : IRequestHandler<CreatePersonCommand, Guid>
    {
        private readonly IPersonRepository _repo;

        public CreatePersonHandler(IPersonRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreatePersonCommand request, CancellationToken ct)
        {
            var person = new Person(request.Name, new Cpf(request.Cpf), request.Age);
            await _repo.AddAsync(person);
            return person.Id;
        }
    }

}
