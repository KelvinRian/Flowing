using Flowing.Domain.Dtos.Goals;
using Flowing.Domain.Entities;

namespace Flowing.Domain.Interfaces.Repositories
{
    public interface IGoalRepository
    {
        Task Add(Goal goal);
        Task<Goal> Get(Guid id);
        Task Update(Goal goal);
        Task<IReadOnlyList<GoalDto>> GetAll();
        Task<GoalWithActionsDto> GetWithActions(Guid id);
    }
}
