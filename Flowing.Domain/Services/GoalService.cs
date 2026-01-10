using Flowing.Domain.Commands;
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
            throw new NotImplementedException();
        }
    }
}
