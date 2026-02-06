using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Dtos.Goals;

namespace Flowing.Domain.Interfaces.Services
{
    public interface IGoalService
    {
        Task AddGoal(AddGoalCommand command);
        Task UpdateGoal(Guid id, UpdateGoalCommand command);
        Task Finish(Guid id);
        Task<IReadOnlyList<GoalDto>> GetAll();
        Task Inactivate(Guid id);
    }
}
