using MediatR;
using Vinculo.Application.DTOs;
using Vinculo.Application.Queries;
using Vinculo.Domain.Entities;
using Vinculo.Domain.Interfaces;

namespace Vinculo.Application.Handlers;

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
            Id = Vinculo.Id,
            Name = Vinculo.Name
        };
    }
}
