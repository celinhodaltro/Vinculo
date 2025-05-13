using MediatR;

namespace Vinculo.Application.Commands
{
    public class RemovePersonCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }
}
