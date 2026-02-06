using Flowing.Domain.Commands.Action;
using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Entities;
using Flowing.Domain.Enums;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Services;
using NSubstitute;
using System.Formats.Asn1;
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

        [Fact]
        public async Task ShouldInactivate()
        {
            // Arrange
            var commandAction = new AddActionCommand();
            var action = new EntityAction(commandAction, Guid.NewGuid());
            action.Id = Guid.NewGuid();
            _actionRepository.Get(action.Id).Returns(action);

            // Act
            await _actionService.Inactivate(action.Id);

            // Assert
            await _actionRepository
                .Received(1)
                .Update(Arg.Is<EntityAction>(x => x.Id == action.Id && x.Active == false));
        }

        [Fact]
        public async Task ShouldNotInactivate()
        {
            // Act
            await _actionService.Inactivate(Guid.NewGuid());

            // Assert
            await _actionRepository
                .DidNotReceive()
                .Update(Arg.Any<EntityAction>());
        }

        [Fact]
        public async Task ShouldChangeStatus()
        {
            // Arrange
            var commandAction = new AddActionCommand();
            var action = new EntityAction(commandAction, Guid.NewGuid());
            action.Id = Guid.NewGuid();
            _actionRepository.Get(action.Id).Returns(action);

            // Act
            await _actionService.ChangeStatus(action.Id, Status.Doing);

            // Assert
            await _actionRepository
                .Received(1)
                .Update(Arg.Is<EntityAction>(x => x.Id == action.Id && x.Status == Status.Doing));
        }
    }
}
