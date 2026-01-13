using Flowing.Domain.Commands.Goal;
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

        [Fact]
        public void ShouldUpdateCommand()
        {
            // Arrange
            var initialCommand = new AddGoalCommand
            {
                Title = "Initial Title",
                Description = "Initial Description"
            };
            var goal = new Goal(initialCommand);

            var updateCommand = new UpdateGoalCommand
            {
                Title = "Updated Title",
                Description = "Updated Description"
            };

            // Act
            goal.Update(updateCommand);

            // Assert
            Assert.Equal(updateCommand.Title, goal.Title);
            Assert.Equal(updateCommand.Description, goal.Description);
        }
    }
}
