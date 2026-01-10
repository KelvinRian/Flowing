using Flowing.Domain.Enums;

namespace Flowing.Domain.Entities
{
    public class Action : Entity
    {
        public string Name { get; set; }
        public Status Status { get; set; }
    }
}
