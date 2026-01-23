using Flowing.Domain.Interfaces.Repositories;
using Flowing.Infrastructure.Context;

namespace Flowing.Infrastructure.Repositories
{
    public class ActionRepository : IActionRepository
    {
        private FlowingContext _context;

        public ActionRepository(FlowingContext context)
        {
            _context = context;
        }

        public async Task Add(Domain.Entities.Action action)
        {
            await _context.Actions.AddAsync(action);
            await _context.SaveChangesAsync();
        }
    }
}
