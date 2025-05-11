using MediatR;

namespace Person.Application.Commands
{
    public class RemovePersonCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
