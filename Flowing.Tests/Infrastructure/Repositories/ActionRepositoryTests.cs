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
    public class ActionRepositoryTests
    {
        [Fact]
        public async Task ShouldAddAction()
        {
            // Arrange
            var mockContext = Create.MockedDbContextFor<FlowingContext>();

            var goalId = Guid.NewGuid();

            var goalCommand = new AddGoalCommand()
            {
                Title = "Goal test",
                Description = "Goal Description"
            };

            var goal = new Goal(goalCommand);
            typeof(Goal).GetProperty("Id")!.SetValue(goal, goalId);
            await mockContext.Goals.AddAsync(goal);
            await mockContext.SaveChangesAsync();

            var repository = new ActionRepository(mockContext);

            var command = new AddActionCommand
            {
                Name = "test name"
            };

            var action = new EntityAction(command, goalId);

            // Act
            await repository.Add(action);

            // Assert
            var addedAction = await mockContext.Actions.FirstOrDefaultAsync();

            Assert.NotNull(addedAction);
            Assert.Equal(addedAction.Name, addedAction.Name);
        }
    }
}
