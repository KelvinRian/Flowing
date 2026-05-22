using Flowing.Domain.Entities;

namespace Flowing.Domain.Dtos.Goals
{
    public class GoalDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int NumberOfCompletedActions { get; set; }
        public int TotalActions { get; set; }
        
        public GoalDto(Goal goal) 
        {
            Id = goal.Id;
            Title = goal.Title;
            NumberOfCompletedActions = goal.Actions.Count(x => x.Status == Enums.Status.Completed);
            TotalActions = goal.Actions.Count();
        }
    }
}
