using Flowing.Domain.Commands.Action;
using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Entities;
using Flowing.Domain.Enums;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Notifications;
using Flowing.Domain.Services;
using Flowing.Infrastructure.Repositories;
using NSubstitute;
using System.Formats.Asn1;
using EntityAction = Flowing.Domain.Entities.Action;

namespace Flowing.Tests.Domain.Services
{
    public class ActionServiceTests
    {
        private readonly IActionService _actionService;
        private readonly IActionRepository _actionRepository;
        private readonly IGoalRepository _goalRepository;
        private readonly IDomainNotificationHandler _notifications;

        public ActionServiceTests()
        {
            _actionRepository = Substitute.For<IActionRepository>();
            _goalRepository = Substitute.For<IGoalRepository>();
            _notifications = new DomainNotificationHandler();

            _actionService = new ActionService(_actionRepository, _goalRepository, _notifications);
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
            var goal = new Goal(new AddGoalCommand());

            _goalRepository.Get(goalId).Returns(goal);

            // Act
            await _actionService.Add(command, goalId);

            // Assert
            await _actionRepository
                .Received(1)
                .Add(Arg.Is<EntityAction>(x => x.GoalId == goalId
                                             && x.Name == command.Name));
        }

        [Fact]
        public async Task ShouldNotAddAction()
        {
            // Arrange
            var command = new AddActionCommand()
            {
                Name = "test name"
            };
            var goalId = Guid.NewGuid();

            // Act
            await _actionService.Add(command, goalId);

            // Assert
            Assert.True(_notifications.HasNotifications());

            var notification = _notifications
                .GetNotifications()
                .Single();

            Assert.Equal("Goal.NotFound", notification.Key);
            Assert.Equal("Meta não encontrada.", notification.Message);
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

        [Fact]
        public async Task ShouldNotChangeStatus()
        {
            // Arrange
            var commandAction = new AddActionCommand();
            var action = new EntityAction(commandAction, Guid.NewGuid());
            action.Id = Guid.NewGuid();

            // Act
            await _actionService.ChangeStatus(action.Id, Status.Doing);

            // Assert
            Assert.True(_notifications.HasNotifications());

            var notification = _notifications
                .GetNotifications()
                .Single();

            Assert.Equal("Action.NotFound", notification.Key);
            Assert.Equal("Ação não encontrada.", notification.Message);
        }
    }
}
