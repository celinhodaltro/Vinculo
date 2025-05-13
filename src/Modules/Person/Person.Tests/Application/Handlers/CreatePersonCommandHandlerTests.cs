using FluentAssertions;
using Moq;
using Person.Application.Commands;
using Person.Application.Handlers;
using Person.Domain.Entities;
using Person.Domain.Interfaces;

namespace Person.Tests.Application.Handlers
{
    public class CreatePersonCommandHandlerTests
    {
        [Fact]
        public async Task Handle_ShouldReturnSuccess_WhenPersonIsValid()
        {
            // Arrange
            var mockRepo = new Mock<IPersonRepository>();
            var handler = new CreatePersonHandler(mockRepo.Object);
            var command = new CreatePersonCommand { Name = "João", Age = 30 };

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            result.Should().NotBeEmpty();
            mockRepo.Verify(r => r.AddAsync(It.IsAny<User>()), Times.Once);
        }
    }

}
