using Flowing.Domain.Entities;
using Flowing.Domain.Enums;

namespace Flowing.Domain.Dtos.Goals
{
    public class GoalDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }

        public GoalDto(Goal goal) 
        {
            Id = goal.Id;
            Title = goal.Title;
            Description = goal.Description;
            Status = goal.Status;
        }
    }
}
