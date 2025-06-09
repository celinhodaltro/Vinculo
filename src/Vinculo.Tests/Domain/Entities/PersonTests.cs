using FluentAssertions;
using Vinculo.Domain.Entities;
using Vinculo.Domain.ValueObjects;

namespace Vinculo.Tests.Domain.Entities
{
    public class PersonTests
    {
        [Fact]
        public void Constructor_ShouldSetPropertiesCorrectly()
        {
            var person = new Person("Maria", new Cpf("000.000.000-00") , 25);
            person.Name.Should().Be("Maria");
            person.Age.Should().Be(25);
            person.Cpf.ToString().Should().Be("000.000.000-00");
        }
    }
}
