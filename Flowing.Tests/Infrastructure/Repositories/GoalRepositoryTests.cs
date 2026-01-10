using EntityFrameworkCore.Testing.Moq;
using Flowing.Domain.Commands;
using Flowing.Domain.Entities;
using Flowing.Infrastructure.Context;
using Flowing.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Flowing.Tests.Infrastructure.Repositories
{
    public class GoalRepositoryTests
    {
        [Fact]
        public async Task ShouldAddGoal()
        {
            // Arrange
            var mockContext = Create.MockedDbContextFor<FlowingContext>();

            var repository = new GoalRepository(mockContext);

            var command = new AddGoalCommand
            {
                Title = "New Goal",
                Description = "Goal Description"
            };

            var goal = new Goal(command);

            // Act
            await repository.Add(goal);

            // Assert
            var addedGoal = await mockContext.Goals.FirstOrDefaultAsync();
            
            Assert.NotNull(addedGoal);
            Assert.Equal(addedGoal.Title, addedGoal.Title);
        }
    }
}
