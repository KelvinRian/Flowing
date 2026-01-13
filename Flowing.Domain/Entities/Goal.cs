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

        private Goal() { }

        public Goal(AddGoalCommand addGoalCommand)
        {
            Id = Guid.NewGuid();
            Title = addGoalCommand.Title;
            Description = addGoalCommand.Description;
        }

        public void Update(UpdateGoalCommand command)
        {
            Title = command.Title;
            Description = command.Description;
        }
    }
}
