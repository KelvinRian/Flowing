using EntityFrameworkCore.Testing.Moq;
using Flowing.Domain.Commands.Action;
using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Entities;
using Flowing.Infrastructure.Context;
using Flowing.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using EntityAction = Flowing.Domain.Entities.Action;

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
        public async Task ShouldNotGetByIdWhenNotActive()
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
            goal.Active = false;

            await mockContext.Goals.AddAsync(goal);
            await mockContext.SaveChangesAsync();

            // Act
            var result = await repository.Get(goal.Id);

            // Assert
            Assert.Null(result);
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

            var commandForInactiveGoal = new AddGoalCommand
            {
                Title = "Inactive Goal",
                Description = "Description Inactive Goal"
            };
            var inactiveGoal = new Goal(commandForInactiveGoal);
            inactiveGoal.Active = false;
            await mockContext.Goals.AddAsync(inactiveGoal);

            await mockContext.SaveChangesAsync();

            // Act
            var result = await repository.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Contains(result, x => x.Title == "Goal 1");
            Assert.Contains(result, x => x.Title == "Goal 2");
        }

        [Fact]
        public async Task ShouldReturnEmptyDtoWhenGetWithActionsHaveNoGoal()
        {
            // Arrange
            var mockContext = Create.MockedDbContextFor<FlowingContext>();
            var repository = new GoalRepository(mockContext);
            var nonExistentId = Guid.NewGuid();

            // Act
            var result = await repository.GetWithActions(nonExistentId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(Guid.Empty, result.Id);
            Assert.Empty(result.Actions);
        }

        [Fact]
        public async Task ShouldGetWithActions()
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

            var actionCommand = new AddActionCommand
            {
                Name = "New Action"
            };
            var action = new EntityAction(actionCommand, goal.Id);
            action.Id = Guid.NewGuid();
            await mockContext.Actions.AddAsync(action);

            await mockContext.SaveChangesAsync();
            
            // Act
            var result = await repository.GetWithActions(goal.Id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(goal.Id, result.Id);
            Assert.Equal(goal.Title, result.Title);
            Assert.Equal(goal.Description, result.Description);
            Assert.Equal(goal.Status, result.Status);
            Assert.Single(result.Actions);
            Assert.Equal(action.Id, result.Actions.First().Id);
            Assert.Equal(action.Name, result.Actions.First().Name);
            Assert.Equal(action.Status, result.Actions.First().Status);
        }
    }
}
