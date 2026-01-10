using Flowing.Domain.Entities;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Infrastructure.Context;

namespace Flowing.Infrastructure.Repositories
{
    public class GoalRepository : IGoalRepository
    {
        private FlowingContext _context;

        public GoalRepository(FlowingContext context)
        {
            _context = context;
        }

        public async Task Add(Goal goal)
        {
            await _context.Goals.AddAsync(goal);
            await _context.SaveChangesAsync();
        }
    }
}
