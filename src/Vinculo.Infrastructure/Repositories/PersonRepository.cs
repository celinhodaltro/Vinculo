using Microsoft.EntityFrameworkCore;
using Vinculo.Domain.Entities;
using Vinculo.Domain.Interfaces;
using Vinculo.Infrastructure.Persistence;

namespace Vinculo.Infrastructure.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly AppDbContext _context;

        public PersonRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Person user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Guid Id)
        {
            var userToDelete = await _context.Users.FirstOrDefaultAsync(p => p.Id == Id); 

            _context.Users.Remove(userToDelete!);
            await _context.SaveChangesAsync();
        }


        public async Task<Person?> GetByIdAsync(Guid id)
        {
            return await _context.Users.FirstOrDefaultAsync(p => p.Id == id);
        }
    }

}
