using Flowing.Domain.Commands.Action;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Domain.Interfaces.Services;
using EntityAction = Flowing.Domain.Entities.Action;

namespace Flowing.Domain.Services
{
    public class ActionService : IActionService
    {
        private readonly IActionRepository _actionRepository;

        public ActionService(IActionRepository actionRepository)
        {
            _actionRepository = actionRepository;
        }

        public async Task AddAction(AddActionCommand command, Guid goalId)
        {
            // TODO
            // Null Goal validation
            // Command Validation
            var action = new EntityAction(command, goalId);
            await _actionRepository.Add(action);
        }
    }
}
