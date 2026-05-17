namespace Flowing.Domain.Commands.Goal
{
    public abstract class GoalCommand
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
