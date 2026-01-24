using Flowing.Domain.Commands.Action;
using Flowing.Domain.Enums;

namespace Flowing.Domain.Entities
{
    public class Action : Entity
    {
        public string Name { get; set; }
        public Status Status { get; set; }
        public Goal Goal { get; set; }
        public Guid GoalId { get; set; }
        public bool Active { get; set; }

        private Action() { }

        public Action(AddActionCommand command, Guid goalId)
        {
            Id = Guid.NewGuid();
            Name = command.Name;
            Status = Status.Pending;
            GoalId = goalId;
            Active = true;
        }

        public void Update(ActionCommand command)
        {
            Name = command.Name;
        }

        public void Inactivate()
        {
            Active = false;
        }
    }
}
