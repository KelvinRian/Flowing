using Flowing.Domain.Commands;
using Flowing.Domain.Entities;
using Flowing.Domain.Enums;

namespace Flowing.Tests.Domain.Entities
{
    public class GoalTests
    {
        [Fact]
        public void ShouldConstructFromCommand()
        {
            // Arrange
            var command = new AddGoalCommand
            {
                Title = "Test Title",
                Description = "Test Description"
            };

            // Act
            var goal = new Goal(command);

            // Assert
            Assert.NotEqual(goal.Id, Guid.Empty);
            Assert.Equal(command.Title, goal.Title);
            Assert.Equal(command.Description, goal.Description);
            Assert.Equal(Status.Pending, goal.Status);
            Assert.Empty(goal.Actions);
        }
    }
}
