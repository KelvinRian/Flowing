using Flowing.Api.Controllers;
using Flowing.Domain.Commands.Action;
using Flowing.Domain.Interfaces.Services;
using NSubstitute;

namespace Flowing.Tests.Api.Controllers
{
    public class ActionsControllerTests
    {
        private readonly ActionsController _controller;
        private readonly IActionService _actionService;

        public ActionsControllerTests()
        {
            _actionService = Substitute.For<IActionService>();
            _controller = new ActionsController(_actionService);
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
    }
}
