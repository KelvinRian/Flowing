using Flowing.Domain.Commands.Action;

namespace Flowing.Domain.Interfaces.Services
{
    public interface IActionService
    {
        Task AddAction(AddActionCommand command, Guid goalId);
        Task UpdateAction(UpdateActionCommand command, Guid actionId);
        Task Inactivate(Guid actionId);
    }
}
