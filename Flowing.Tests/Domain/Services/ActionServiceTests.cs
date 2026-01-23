using Flowing.Domain.Commands.Action;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Services;
using NSubstitute;
using EntityAction = Flowing.Domain.Entities.Action;

namespace Flowing.Tests.Domain.Services
{
    public class ActionServiceTests
    {
        private readonly IActionService _actionService;
        private readonly IActionRepository _actionRepository;

        public ActionServiceTests()
        {
            _actionRepository = Substitute.For<IActionRepository>();
            _actionService = new ActionService(_actionRepository);
        }

        [Fact]
        public async Task ShouldAddAction()
        {
            // Arrange
            var command = new AddActionCommand()
            {
                Name = "test name"
            };
            var goalId = Guid.NewGuid();

            // Act
            await _actionService.AddAction(command, goalId);

            // Assert
            await _actionRepository
                .Received(1)
                .Add(Arg.Is<EntityAction>(x => x.GoalId == goalId
                                             && x.Name == command.Name));
        }
    }
}
