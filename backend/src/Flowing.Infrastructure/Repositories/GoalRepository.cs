using Flowing.Domain.Dtos.Goals;
using Flowing.Domain.Entities;
using Flowing.Domain.Interfaces.Repositories;
using Flowing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Goal> Get(Guid id)
        {
            return await _context
                .Goals
                .FirstOrDefaultAsync(g => g.Id == id && g.Active);
        }

        public async Task<IReadOnlyList<Goal>> GetAllWithActions()
        {
            return await _context
                .Goals
                .Where(x => x.Active)
                .Include(x => x.Actions)
                .ToListAsync();
        }

        public async Task<GoalWithActionsDto> GetWithActions(Guid id)
        {
            var goal = await _context
                .Goals
                .Include(x => x.Actions)
                .FirstOrDefaultAsync(g => g.Id == id && g.Active);

            if (goal is null) return new GoalWithActionsDto();

            return new GoalWithActionsDto(goal);
        }

        public async Task Update(Goal goal)
        {
            _context.Goals.Update(goal);
            await _context.SaveChangesAsync();
        }
    }
}
