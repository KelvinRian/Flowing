using Flowing.Domain.Commands;
using Flowing.Domain.Entities;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Domain.Interfaces.Services;

namespace Flowing.Domain.Services
{
    public class GoalService : IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository)
        {
            _goalRepository = goalRepository;
        }

        public async Task AddGoal(AddGoalCommand command)
        {
            var goal = new Goal(command);
            await _goalRepository.Add(goal);
        }
    }
}
