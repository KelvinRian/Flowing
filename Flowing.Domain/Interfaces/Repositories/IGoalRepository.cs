using Flowing.Domain.Entities;

namespace Flowing.Domain.Interfaces.Repositories
{
    public interface IGoalRepository
    {
        Task Add(Goal goal);
    }
}
