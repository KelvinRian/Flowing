using Flowing.Domain.Commands.Goal;
using Flowing.Domain.Enums;

namespace Flowing.Domain.Entities
{
    public class Goal : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public IEnumerable<Action> Actions { get; set; } = new List<Action>();
        public bool Active { get; set; }

        private Goal() { }

        public Goal(AddGoalCommand addGoalCommand)
        {
            Id = Guid.NewGuid();
            Title = addGoalCommand.Title;
            Description = addGoalCommand.Description;
            Active = true;
        }

        public void Update(UpdateGoalCommand command)
        {
            Title = command.Title;
            Description = command.Description;
        }

        public void Finish()
        {
            Status = Status.Done;
        }

        public void Inactivate()
        {
            Active = false;
        }
    }
}
