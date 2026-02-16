using Flowing.Domain.Dtos.Actions;
using Flowing.Domain.Entities;
using Flowing.Domain.Enums;

namespace Flowing.Domain.Dtos.Goals
{
    public class GoalWithActionsDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public IEnumerable<ActionDto> Actions{ get; set; } = new List<ActionDto>();

        public GoalWithActionsDto(Goal goal)
        {
            Id = goal.Id;
            Title = goal.Title;
            Description = goal.Description;
            Status = goal.Status;
            Actions = goal.Actions.Select(x => new ActionDto(x));
        }

        public GoalWithActionsDto() { }
    }
}
