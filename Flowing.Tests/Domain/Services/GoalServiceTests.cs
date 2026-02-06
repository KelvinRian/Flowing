using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Dtos.Goals;
using Flowing.Domain.Entities;
using Flowing.Domain.Enums;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Services;
using NSubstitute;

namespace Flowing.Tests.Domain.Services
{
    public class GoalServiceTests
    {
        private readonly IGoalService _goalService;
        private readonly IGoalRepository _goalRepository;

        public GoalServiceTests()
        {
            _goalRepository = Substitute.For<IGoalRepository>();
            _goalService = new GoalService(_goalRepository);
        }

        [Fact]
        public async Task ShouldAddGoal()
        {
            // Arrange
            var command = new AddGoalCommand()
            {
                Title = "Test Title",
                Description = "Test Description",
            };

            // Act
            await _goalService.AddGoal(command);

            // Assert
            await _goalRepository
                .Received(1)
                .Add(Arg.Is<Goal>(x => x.Id != Guid.Empty &&
                                       x.Title == command.Title &&
                                       x.Description == command.Description));
        }

        [Fact]
        public async Task ShouldUpdateGoal()
        {
            //Arrange
            var goalId = Guid.NewGuid();
            var command = new UpdateGoalCommand()
            {
                Title = "Updated Title",
                Description = "Updated Description",
            };

            var existingGoal = new Goal(new AddGoalCommand()
            {
                Title = "Initial Title",
                Description = "Initial Description",
            });
            existingGoal.Id = goalId;
            _goalRepository.Get(goalId).Returns(existingGoal);

            // Act 
            await _goalService.UpdateGoal(goalId, command);

            // Assert
            await _goalRepository
                .Received(1)
                .Update(Arg.Is<Goal>(x => x.Id == goalId &&
                                         x.Title == command.Title &&
                                         x.Description == command.Description));
        }

        [Fact]
        public async Task ShouldFinish()
        {
            // Arrange
            var goalId = Guid.NewGuid();
            var existingGoal = new Goal(new AddGoalCommand());
            existingGoal.Id = goalId;

            _goalRepository.Get(goalId).Returns(existingGoal);

            // Act
            await _goalService.Finish(goalId);

            // Assert
            await _goalRepository
                .Received(1)
                .Update(Arg.Is<Goal>(x => x.Id == goalId &&
                                         x.Status == Status.Done));
        }

        [Fact]
        public async Task ShouldGetAll()
        {
            // Arrange
            var goalsDto = new List<GoalDto>();
            _goalRepository.GetAll().Returns(goalsDto);

            // Act
            var result = await _goalService.GetAll();

            // Assert
            Assert.Equal(goalsDto, result);
        }

        [Fact]
        public async Task ShouldInactivate()
        {
            // Arrange
            var goalId = Guid.NewGuid();
            var existingGoal = new Goal(new AddGoalCommand());
            existingGoal.Id = goalId;
            _goalRepository.Get(goalId).Returns(existingGoal);

            // Act
            await _goalService.Inactivate(goalId);
            
            // Assert
            await _goalRepository
                .Received(1)
                .Update(Arg.Is<Goal>(x => x.Id == goalId &&
                                         x.Active == false));
        }

        [Fact]
        public async Task ShouldGetWithActions()
        {
            // Arrange
            var goalId = Guid.NewGuid();
            var goalWithActionsDto = new GoalWithActionsDto(new Goal(new AddGoalCommand()));
            _goalRepository.GetWithActions(goalId).Returns(goalWithActionsDto);
            
            // Act
            var result = await _goalService.GetWithActions(goalId);
            
            // Assert
            Assert.Equal(goalWithActionsDto, result);
        }
    }
}
