using Forum.Core.Messages;
using System;

namespace Forum.Application.Events
{
    public class SectionCreatedEvent : Event
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public SectionCreatedEvent(Guid id, string name,bool active)
        {
            AggregateId = id;
            Name = name;
            IsActive = active;
        }
    }
}
