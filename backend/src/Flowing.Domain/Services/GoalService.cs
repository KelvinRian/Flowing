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

        public async Task Add(AddGoalCommand command)
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
            var goal = await _goalRepository.Get(id);
            if (goal == null)
            {
                Notify(
                    key: "Goal.NotFound",
                    message: "Meta não encontrada."
                );
                return;
            }

            goal.Finish();
            await _goalRepository.Update(goal);
        }

        public async Task<IReadOnlyList<GoalDto>> GetAll()
        {
            return await _goalRepository.GetAll();
        }

        public async Task Update(Guid id, UpdateGoalCommand command)
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

            goal.Update(command);
            await _goalRepository.Update(goal);
        }

        public async Task<GoalWithActionsDto> GetWithActions(Guid id)
        {
            return await _goalRepository.GetWithActions(id);
        }
    }
}
