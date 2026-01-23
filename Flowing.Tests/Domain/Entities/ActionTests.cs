using Flowing.Domain.Commands.Action;
using Flowing.Domain.Enums;
using EntityAction = Flowing.Domain.Entities.Action;

namespace Flowing.Tests.Domain.Entities
{
    public class ActionTests
    {
        [Fact]
        public void ShouldCreateAction()
        {
            // Arrange
            var command = new AddActionCommand
            {
                Name = "Test Action"
            };
            var goalId = Guid.NewGuid();

            // Act
            var action = new EntityAction(command, goalId);

            // Assert
            Assert.NotEqual(action.Id, Guid.Empty);
            Assert.Equal(command.Name, action.Name);
            Assert.Equal(Status.Pending, action.Status);
            Assert.Equal(action.GoalId, goalId);
        }
    }
}
