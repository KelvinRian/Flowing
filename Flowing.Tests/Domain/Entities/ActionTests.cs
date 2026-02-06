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
            Assert.True(action.Active);
            Assert.Equal(action.GoalId, goalId);
        }

        [Fact]
        public void ShouldUpdateAction()
        {
            // Arrange
            var command = new AddActionCommand
            {
                Name = "Initial Action"
            };
            var goalId = Guid.NewGuid();
            var action = new EntityAction(command, goalId);

            var updateCommand = new UpdateActionCommand
            {
                Name = "Updated Action"
            };

            // Act
            action.Update(updateCommand);

            // Assert
            Assert.Equal(updateCommand.Name, action.Name);
        }

        [Fact]
        public void ShouldInactivate()
        {
            // Arrange
            var command = new AddActionCommand
            {
                Name = "Test Action"
            };
            var goalId = Guid.NewGuid();
            var action = new EntityAction(command, goalId);

            // Act
            action.Inactivate();

            // Assert
            Assert.False(action.Active);
        }

        [Fact]
        public void ShouldChangeStatus()
        {
            // Arrange
            var command = new AddActionCommand
            {
                Name = "Test Action"
            };
            var goalId = Guid.NewGuid();
            var action = new EntityAction(command, goalId);

            // Act
            action.ChangeStatus(Status.Doing);

            // Assert
            Assert.Equal(Status.Doing, action.Status);
        }
    }
}
