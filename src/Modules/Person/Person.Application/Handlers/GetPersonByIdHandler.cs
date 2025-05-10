using MediatR;
using Person.Application.DTOs;
using Person.Application.Queries;
using Person.Domain.Entities;
using Person.Domain.Interfaces;

namespace Person.Application.Handlers;

public class GetPersonByIdHandler : IRequestHandler<GetPersonByIdQuery, PersonDto?>
{
    private readonly IPersonRepository _repo;

    public GetPersonByIdHandler(IPersonRepository repo)
    {
        _repo = repo;
    }

    public async Task<PersonDto?> Handle(GetPersonByIdQuery request, CancellationToken ct)
    {
        var person = await _repo.GetByIdAsync(request.Id);
        if (person == null) return null;

        return new PersonDto
        {
            Id = person.Id,
            Name = person.Name
        };
    }
}
