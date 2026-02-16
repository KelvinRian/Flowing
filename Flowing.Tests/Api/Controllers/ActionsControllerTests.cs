using Flowing.Api.Controllers;
using Flowing.Domain.Commands.Action;
using Flowing.Domain.Enums;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Notifications;
using NSubstitute;

namespace Flowing.Tests.Api.Controllers
{
    public class ActionsControllerTests
    {
        private readonly ActionsController _controller;
        private readonly IActionService _actionService;
        private readonly IDomainNotificationHandler _notifications;

        public ActionsControllerTests()
        {
            _actionService = Substitute.For<IActionService>();
            _notifications = new DomainNotificationHandler();
            _controller = new ActionsController(_actionService, _notifications);
        }

        [Fact]
        public async Task ShouldAddAction()
        {
            // Arrange
            var command = new AddActionCommand();
            var goalId = Guid.NewGuid();

            // Act
            var result = await _controller.AddAction(goalId, command);

            // Assert
            await _actionService
                .Received(1)
                .AddAction(command, goalId);
        }

        [Fact]
        public async Task ShouldUpdateAction()
        {
            // Arrange
            var command = new UpdateActionCommand();
            var actionId = Guid.NewGuid();

            // Act
            var result = await _controller.UpdateAction(actionId, command);

            // Assert
            await _actionService
                .Received(1)
                .UpdateAction(command, actionId);
        }

        [Fact]
        public async Task ShouldInactivate()
        {
            // Arrange
            var actionId = Guid.NewGuid();

            // Act
            var result = await _controller.Inactivate(actionId);
            
            // Assert
            await _actionService
                .Received(1)
                .Inactivate(actionId);
        }

        [Fact]
        public async Task ShouldChangeStatus()
        {
            // Arrange
            var actionId = Guid.NewGuid();
            var status = Status.Doing;

            // Act
            var result = await _controller.ChangeStatus(actionId, status);
            
            // Assert
            await _actionService
                .Received(1)
                .ChangeStatus(actionId, status);
        }
    }
}
