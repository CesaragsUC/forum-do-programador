using Forum.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.Events.Topic
{
    public class TopicReplyEvent : Event
    {
        //Id Topic
        public Guid TopicId { get; private set; }
        public Guid UserId { get; private set; }

        //user name that reply a topic
        public string Name { get; private set; }

        public TopicReplyEvent(Guid topicId, Guid userId, string name)
        {
            TopicId = topicId;
            AggregateId = topicId;
            UserId = userId;
            Name = name;
        }
    }
}
