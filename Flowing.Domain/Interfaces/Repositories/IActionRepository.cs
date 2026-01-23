using EntityAction = Flowing.Domain.Entities.Action;

namespace Flowing.Domain.Interfaces.Repositories
{
    public interface IActionRepository
    {
        Task Add(EntityAction action);
        Task Update(EntityAction action);
        Task<EntityAction> Get(Guid id);
    }
}
