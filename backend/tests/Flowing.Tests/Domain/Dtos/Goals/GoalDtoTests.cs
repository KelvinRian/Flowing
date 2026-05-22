using Flowing.Domain.Commands.Action;
using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Dtos.Goals;
using Flowing.Domain.Entities;
using Action = Flowing.Domain.Entities.Action;
using Flowing.Domain.Enums;

namespace Flowing.Tests.Domain.Dtos.Goals
{
    public class GoalDtoTests
    {
        [Fact]
        public void ShouldConstructDto()
        {
            // Arrange
            var command = new AddGoalCommand()
            {
                Title = "Test Goal",
                Description = "This is a test goal"
            };
            var goal = new Goal(command);
            goal.Id = Guid.NewGuid();
            goal.Status = Status.Completed;

            var notCompletedActionCommand = new AddActionCommand() { };
            var notCompletedAction = new Action(notCompletedActionCommand, goal.Id);

            var completedActionCommand = new AddActionCommand() { };
            var completedAction = new Action(completedActionCommand, goal.Id);
            completedAction.ChangeStatus(Status.Completed);

            goal.Actions = new List<Action> { completedAction, notCompletedAction };

            // Act
            var dto = new GoalDto(goal);

            // Assert
            Assert.Equal(goal.Id, dto.Id);
            Assert.Equal(goal.Title, dto.Title);
            Assert.Equal(1, dto.NumberOfCompletedActions);
            Assert.Equal(2, dto.TotalActions);
        }
    }
}
