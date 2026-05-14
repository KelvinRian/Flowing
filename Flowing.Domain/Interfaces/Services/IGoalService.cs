using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Dtos.Goals;

namespace Flowing.Domain.Interfaces.Services
{
    public interface IGoalService
    {
        Task Add(AddGoalCommand command);
        Task Update(Guid id, UpdateGoalCommand command);
        Task Finish(Guid id);
        Task<IReadOnlyList<GoalDto>> GetAll();
        Task Inactivate(Guid id);
        Task<GoalWithActionsDto> GetWithActions(Guid id);
    }
}
