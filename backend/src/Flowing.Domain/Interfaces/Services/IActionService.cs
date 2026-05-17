using Flowing.Domain.Commands.Action;
using Flowing.Domain.Enums;

namespace Flowing.Domain.Interfaces.Services
{
    public interface IActionService
    {
        Task Add(AddActionCommand command, Guid goalId);
        Task Update(UpdateActionCommand command, Guid actionId);
        Task Inactivate(Guid actionId);
        Task ChangeStatus(Guid actionId, Status newStatus);
    }
}
