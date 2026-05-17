using Flowing.Domain.Commands.Action;
using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Dtos.Goals;
using Flowing.Domain.Entities;
using EntityAction = Flowing.Domain.Entities.Action;

namespace Flowing.Tests.Domain.Dtos.Goals
{
    public class GoalWithActionsDtoTests
    {
        [Fact]
        public void ShouldConstructDto()
        {
            // Arrange
            var goalCommand = new AddGoalCommand()
            {
                Title = "Test Goal",
                Description = "Test Description"
            };

            var goal = new Goal(goalCommand);
            goal.Id = Guid.NewGuid();

            var actionCommand = new AddActionCommand()
            {
                Name = "Test Action"
            };

            var action = new EntityAction(actionCommand, goal.Id);
            action.Id = Guid.NewGuid();

            goal.Actions = new List<EntityAction>() { action };

            // Act
            var dto = new GoalWithActionsDto(goal);

            // Assert
            Assert.Equal(goal.Id, dto.Id);
            Assert.Equal(goal.Title, dto.Title);
            Assert.Equal(goal.Description, dto.Description);
            Assert.Equal(goal.Status, dto.Status);
            Assert.Equal(goal.Actions.Count(), dto.Actions.Count());
            Assert.Equal(action.Id, dto.Actions.First().Id);
            Assert.Equal(action.Name, dto.Actions.First().Name);
            Assert.Equal(action.Status, dto.Actions.First().Status);
        }
    }
}
