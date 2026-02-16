using Flowing.Domain.Commands.Action;
using Flowing.Domain.Entities;
using Flowing.Domain.Enums;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Domain.Interfaces.Services;
using Flowing.Domain.Notifications;
using EntityAction = Flowing.Domain.Entities.Action;

namespace Flowing.Domain.Services
{
    public class ActionService : BaseService, IActionService
    {
        private readonly IActionRepository _actionRepository;
        private readonly IGoalRepository _goalRepository;

        public ActionService(IActionRepository actionRepository, IGoalRepository goalRepository,
            IDomainNotificationHandler notifications) : base(notifications)
        {
            _actionRepository = actionRepository;
            _goalRepository = goalRepository;
        }

        public async Task AddAction(AddActionCommand command, Guid goalId)
        {
            var goal = await _goalRepository.Get(goalId);
            if (goal == null)
            {
                Notify(
                    key: "Goal.NotFound",
                    message: "Meta não encontrada."
                );
                return;
            };

            // TODO
            // Command Validation
            var action = new EntityAction(command, goalId);
            await _actionRepository.Add(action);
        }

        public async Task ChangeStatus(Guid actionId, Status newStatus)
        {
            var action = await _actionRepository.Get(actionId);
            if (action == null)
            {
                Notify(
                    key: "Action.NotFound",
                    message: "Ação não encontrada."
                );
                return;
            };

            action.ChangeStatus(newStatus);
            await _actionRepository.Update(action);
        }

        public async Task Inactivate(Guid actionId)
        {
            var action = await _actionRepository.Get(actionId);
            if (action == null)
            {
                Notify(
                    key: "Action.NotFound",
                    message: "Ação não encontrada."
                );
                return;
            }

            action.Inactivate();
            await _actionRepository.Update(action);
        }

        public async Task UpdateAction(UpdateActionCommand command, Guid actionId)
        {
            // TODO
            // Command Validation
            var action = await _actionRepository.Get(actionId);
            if (action == null)
            {
                Notify(
                    key: "Action.NotFound",
                    message: "Ação não encontrada."
                );
                return;
            };

            action.Update(command);
            await _actionRepository.Update(action);
        }
    }
}
