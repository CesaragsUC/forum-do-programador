using Forum.Core.Messages;
using System;

namespace Forum.Application.Events
{
    public class TopicCreatedEvent : Event
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }

        public TopicCreatedEvent(Guid id, Guid userId, string name)
        {
            AggregateId = id;
            UserId = userId;
            Name = name;
        }
    }
}
