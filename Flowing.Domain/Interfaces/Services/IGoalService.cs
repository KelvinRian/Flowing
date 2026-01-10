using Flowing.Domain.Commands;

namespace Flowing.Domain.Interfaces.Services
{
    public interface IGoalService
    {
        Task AddGoal(AddGoalCommand command);
    }
}
