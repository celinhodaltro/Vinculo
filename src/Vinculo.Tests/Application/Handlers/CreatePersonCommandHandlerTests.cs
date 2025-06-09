using FluentAssertions;
using Moq;
using Vinculo.Application.Commands;
using Vinculo.Application.Handlers;
using Vinculo.Domain.Entities;
using Vinculo.Domain.Interfaces;

namespace Vinculo.Tests.Application.Handlers
{
    public class CreatePersonCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenPersonIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IPersonRepository>();
            var handler = new CreatePersonHandler(mockRepo.Object);
            var command = new CreatePersonCommand { Name = "João", Age = 30, Cpf = new("000.000.000-00") };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeEmpty();
            mockRepo.Verify(r => r.AddAsync(It.IsAny<Person>()), Times.Once);
        }
    }

}
