using MediatR;
using Vinculo.Application.Commands;
using Vinculo.Domain.Entities;
using Vinculo.Domain.Interfaces;
using Vinculo.Domain.ValueObjects;

namespace Vinculo.Application.Handlers
{
    public class RemovePersonHandler : IRequestHandler<RemovePersonCommand, bool>
    {
        private readonly IPersonRepository _repo;

        public RemovePersonHandler(IPersonRepository repo)
        {
            _repo = repo;
        }

        public async Task<bool> Handle(RemovePersonCommand request, CancellationToken ct)
        {
            try
            {
                await _repo.RemoveAsync(request.Id);
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;

        }
    }

}
