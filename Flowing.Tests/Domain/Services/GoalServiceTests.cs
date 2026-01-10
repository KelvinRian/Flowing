using Flowing.Domain.Commands;
using Flowing.Domain.Entities;
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
    }
}
