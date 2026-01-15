using Flowing.Domain.Commands.Goal;

namespace Flowing.Domain.Interfaces.Services
{
    public interface IGoalService
    {
        Task AddGoal(AddGoalCommand command);
        Task UpdateGoal(Guid id, UpdateGoalCommand command);
        Task Finish(Guid id);
    }
}
