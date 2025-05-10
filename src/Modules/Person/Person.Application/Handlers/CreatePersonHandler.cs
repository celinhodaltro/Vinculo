using MediatR;
using Person.Application.Commands;
using Person.Domain.Entities;
using Person.Domain.Interfaces;
using Person.Domain.ValueObjects;

namespace Person.Application.Handlers
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
            var person = new User(request.Name, new Cpf(request.Cpf));
            await _repo.AddAsync(person);
            return person.Id;

        }
    }

}
