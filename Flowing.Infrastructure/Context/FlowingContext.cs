using Flowing.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using EntityAction = Flowing.Domain.Entities.Action;

namespace Flowing.Infrastructure.Context
{
    public class FlowingContext : DbContext
    {
        public DbSet<Goal> Goals { get; set; }
        public DbSet<EntityAction> Actions { get; set; }

        public FlowingContext(DbContextOptions<FlowingContext> options)
                : base(options)
        {
        }

    }
}
