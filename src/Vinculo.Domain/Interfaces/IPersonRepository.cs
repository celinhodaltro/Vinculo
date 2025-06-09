using Vinculo.Domain.Entities;

namespace Vinculo.Domain.Interfaces;

public interface IPersonRepository
{
    Task AddAsync(Entities.Person person);
    Task RemoveAsync(Guid id);
    Task<Entities.Person?> GetByIdAsync(Guid id);
}
