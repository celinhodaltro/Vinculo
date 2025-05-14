using Vinculo.Domain.Entities;
using Vinculo.Infrastructure.Persistence;
using Vinculo.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vinculo.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using FluentAssertions;

namespace Vinculo.Tests.Infrastructure
{
    public class PersonRepositoryTests
    {
        private readonly AppDbContext _context;
        private readonly PersonRepository _repository;

        public PersonRepositoryTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase("TestDb")
                .Options;

            _context = new AppDbContext(options);
            _repository = new PersonRepository(_context);
        }

        [Fact]
        public async Task AddAsync_ShouldAddPersonToDatabase()
        {
            // Arrange
            var person = new Person("Ana", new Cpf("000.000.000-00"), 22);

            // Act
            await _repository.AddAsync(person);
            var result = await _context.Users.FirstOrDefaultAsync();

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be("Ana");
        }
    }

}
