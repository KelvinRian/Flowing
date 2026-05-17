using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Dtos.Goals;
using Flowing.Domain.Entities;
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
            goal.Status = Status.Done;

            // Act
            var dto = new GoalDto(goal);

            // Assert
            Assert.Equal(goal.Id, dto.Id);
            Assert.Equal(goal.Title, dto.Title);
            Assert.Equal(goal.Description, dto.Description);
            Assert.Equal(goal.Status, dto.Status);
        }
    }
}
