using MediatR;
using Person.Application.DTOs;

namespace Person.Application.Queries;

public class GetPersonByIdQuery : IRequest<PersonDto>
{
    public Guid Id { get; }

    public GetPersonByIdQuery(Guid id)
    {
        Id = id;
    }
}
