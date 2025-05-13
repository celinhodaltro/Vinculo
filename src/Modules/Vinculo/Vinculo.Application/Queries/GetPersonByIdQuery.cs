using MediatR;
using Vinculo.Application.DTOs;

namespace Vinculo.Application.Queries;

public class GetPersonByIdQuery : IRequest<PersonDto>
{
    public Guid Id { get; }

    public GetPersonByIdQuery(Guid id)
    {
        Id = id;
    }
}
