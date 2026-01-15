using Flowing.Api.Controllers;
using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Interfaces.Services;
using NSubstitute;

namespace Flowing.Tests.Api.Controllers
{
    public class GoalsControllerTests
    {
        private readonly IGoalService _goalService;
        private readonly GoalsController _controller;
        
        public GoalsControllerTests()
        {
            _goalService = Substitute.For<IGoalService>();
            _controller = new GoalsController(_goalService);
        }

        [Fact]
        public async Task ShouldAddGoal()
        {
            // Arrange
            var command = new AddGoalCommand();

            // Act
            var result = await _controller.AddGoal(command);

            // Assert
            await _goalService
                .Received(1)
                .AddGoal(command);

            Assert.IsType<Microsoft.AspNetCore.Mvc.OkResult>(result);
        }

        [Fact]
        public async Task ShouldUpdate()
        {
            // Arrange
            var goalId = Guid.NewGuid();
            var command = new UpdateGoalCommand();

            // Act
            var result = await _controller.Update(goalId, command);

            // Assert
            await _goalService
                .Received(1)
                .UpdateGoal(goalId, command);

            Assert.IsType<Microsoft.AspNetCore.Mvc.OkResult>(result);
        }

        [Fact]
        public async Task ShouldFinish()
        {
            // Arrange
            var goalId = Guid.NewGuid();

            // Act
            var result = await _controller.Finish(goalId);

            // Assert
            await _goalService
                .Received(1)
                .Finish(goalId);
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkResult>(result);
        }
    }
}
