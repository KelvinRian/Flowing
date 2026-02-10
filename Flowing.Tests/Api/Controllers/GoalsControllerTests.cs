using Flowing.Api.Controllers;
using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Notifications;
using NSubstitute;

namespace Flowing.Tests.Api.Controllers
{
    public class GoalsControllerTests
    {
        private readonly IGoalService _goalService;
        private readonly IDomainNotificationHandler _notifications;
        private readonly GoalsController _controller;
        
        public GoalsControllerTests()
        {
            _goalService = Substitute.For<IGoalService>();
            _notifications = Substitute.For<IDomainNotificationHandler>();
            _controller = new GoalsController(_goalService, _notifications);
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

        [Fact]
        public async Task ShouldGet()
        {
            // Act
            var result = await _controller.Get();

            // Assert
            await _goalService
                .Received(1)
                .GetAll();
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
        }

        [Fact]
        public async Task ShouldInactivate()
        {
            // Arrange
            var id = Guid.NewGuid();

            // Act
            var result = await _controller.Inactivate(id);

            // Assert
            await _goalService
                .Received(1)
                .Inactivate(id);

            Assert.IsType<Microsoft.AspNetCore.Mvc.NoContentResult>(result);
        }

        [Fact]
        public async Task ShouldGetWithActions()
        {
            // Arrange
            var id = Guid.NewGuid();
            
            // Act
            var result = await _controller.GetWithActions(id);
            
            // Assert
            await _goalService
                .Received(1)
                .GetWithActions(id);
            Assert.IsType<Microsoft.AspNetCore.Mvc.OkObjectResult>(result);
        }
    }
}
