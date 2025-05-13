using FluentAssertions;
using Person.Domain.Entities;
using Person.Domain.ValueObjects;

namespace Person.Tests.Domain.Entities
{
    public class PersonTests
    {
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            var person = new User("Maria", new Cpf("000.000.000-00") , 25);
            person.Name.Should().Be("Maria");
            person.Age.Should().Be(25);
            person.Cpf.Should().Be("000.000.000-00");
        }
    }
}
