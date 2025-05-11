using Person.Domain.Entities;

namespace Person.Domain.Interfaces;

public interface IPersonRepository
{
    Task AddAsync(User person);
    Task RemoveAsync(Guid id);
    Task<User?> GetByIdAsync(Guid id);
}
