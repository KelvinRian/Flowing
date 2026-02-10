using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Dtos.Goals;
using Flowing.Domain.Entities;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Notifications;

namespace Flowing.Domain.Services
{
    public class GoalService : BaseService, IGoalService
    {
        private readonly IGoalRepository _goalRepository;

        public GoalService(IGoalRepository goalRepository,
            IDomainNotificationHandler notifications) : base(notifications)
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
            var goal = await _goalRepository.Get(id);

            if (goal == null)
            {
                Notify(
                    key: "Goal.NotFound",
                    message: "Meta não encontrada."
                );
                return;
            }

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

        public async Task<GoalWithActionsDto> GetWithActions(Guid id)
        {
            return await _goalRepository.GetWithActions(id);
        }
    }
}
