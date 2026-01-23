using EntityFrameworkCore.Testing.Moq;
using Flowing.Domain.Commands;
using Flowing.Domain.Commands.Goal;
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

        [Fact]
        public async Task ShouldGetById()
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
            await mockContext.Goals.AddAsync(goal);
            await mockContext.SaveChangesAsync();

            // Act
            var result = await repository.Get(goal.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(goal.Id, result.Id);
            Assert.Equal(goal.Title, result.Title);
        }

        [Fact]
        public async Task ShouldUpdate()
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
            await mockContext.Goals.AddAsync(goal);
            await mockContext.SaveChangesAsync();

            goal = await repository.Get(goal.Id);
            var updateCommand = new UpdateGoalCommand
            {
                Title = "updated Title",
                Description = "updated Description"
            };
            goal.Update(updateCommand);

            // Act
            await repository.Update(goal);

            // Assert
            var updatedGoal = await repository.Get(goal.Id);
            Assert.Equal(updatedGoal, goal);
        }

        [Fact]
        public async Task ShouldGetAll()
        {
            // Arrange
            var mockContext = Create.MockedDbContextFor<FlowingContext>();
            var repository = new GoalRepository(mockContext);
            
            var command1 = new AddGoalCommand
            {
                Title = "Goal 1",
                Description = "Description 1"
            };
            var goal1 = new Goal(command1);
            await mockContext.Goals.AddAsync(goal1);
            
            var command2 = new AddGoalCommand
            {
                Title = "Goal 2",
                Description = "Description 2"
            };
            var goal2 = new Goal(command2);
            await mockContext.Goals.AddAsync(goal2);
            
            await mockContext.SaveChangesAsync();
            
            // Act
            var result = await repository.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, x => x.Title == "Goal 1");
            Assert.Contains(result, x => x.Title == "Goal 2");
        }
    }
}
