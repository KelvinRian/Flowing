using Flowing.Domain.Commands;
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
            // TODO
        }
    }
}
