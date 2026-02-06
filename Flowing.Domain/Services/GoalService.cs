using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Dtos.Goals;
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

        public async Task Inactivate(Guid id)
        {
            //TODO Null Validation
            var goal = await _goalRepository.Get(id);
            goal.Inactivate();
            await _goalRepository.Update(goal);
        }

        public async Task Finish(Guid id)
        {
            //TODO Null Validation
            var goal = await _goalRepository.Get(id);
            goal.Finish();
            await _goalRepository.Update(goal);
        }

        public async Task<IReadOnlyList<GoalDto>> GetAll()
        {
            return await _goalRepository.GetAll();
        }

        public async Task UpdateGoal(Guid id, UpdateGoalCommand command)
        {
            //TODO Null Validation
            var goal = await _goalRepository.Get(id);
            goal.Update(command);
            await _goalRepository.Update(goal);
        }
    }
}
