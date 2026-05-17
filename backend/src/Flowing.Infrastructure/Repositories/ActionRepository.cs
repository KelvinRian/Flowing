using Flowing.Domain.Interfaces.Repositories;
using Flowing.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

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

        public async Task<Domain.Entities.Action> Get(Guid id)
        {
            return await _context
                .Actions
                .FirstOrDefaultAsync(x => x.Id == id && x.Active);
        }

        public async Task Update(Domain.Entities.Action action)
        {
            _context.Actions.Update(action);
            await _context.SaveChangesAsync();
        }
    }
}
