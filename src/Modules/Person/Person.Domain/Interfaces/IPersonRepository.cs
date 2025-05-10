using Person.Domain.Entities;

namespace Person.Domain.Interfaces;

public interface IPersonRepository
{
    Task AddAsync(User person);
    Task<User?> GetByIdAsync(Guid id);
}
