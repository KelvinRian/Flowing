using Flowing.Domain.Commands.Action;
using Flowing.Domain.Enums;

namespace Flowing.Domain.Interfaces.Services
{
    public interface IActionService
    {
        Task AddAction(AddActionCommand command, Guid goalId);
        Task UpdateAction(UpdateActionCommand command, Guid actionId);
        Task Inactivate(Guid actionId);
        Task ChangeStatus(Guid actionId, Status newStatus);
    }
}
