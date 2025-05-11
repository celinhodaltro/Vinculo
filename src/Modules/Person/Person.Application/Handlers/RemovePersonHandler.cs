using MediatR;
using Person.Application.Commands;
using Person.Domain.Entities;
using Person.Domain.Interfaces;
using Person.Domain.ValueObjects;

namespace Person.Application.Handlers
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
