using Flowing.Domain.Enums;

namespace Flowing.Domain.Entities
{
    public class Goal : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
    }
}
