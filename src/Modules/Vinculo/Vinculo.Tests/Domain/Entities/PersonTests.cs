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
            var person = new Vinculo.Person("Maria", new Cpf("000.000.000-00") , 25);
            Vinculo.Name.Should().Be("Maria");
            Vinculo.Age.Should().Be(25);
            Vinculo.Cpf.Should().Be("000.000.000-00");
        }
    }
}
