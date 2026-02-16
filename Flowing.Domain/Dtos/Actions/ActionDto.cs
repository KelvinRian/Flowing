using EntityAction = Flowing.Domain.Entities.Action;
using Flowing.Domain.Enums;

namespace Flowing.Domain.Dtos.Actions
{
    public class ActionDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Status Status { get; set; }

        public ActionDto(EntityAction action)
        {
            Id = action.Id;
            Name = action.Name;
            Status = action.Status;
        }
    }
}
