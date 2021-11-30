using Forum.Core.DomainObjects;
using System;

namespace Forum.Domain.Entities
{
    public class TopicViews : Entity, IAggregateRoot
    {
        public Guid TopicId { get; private set; }
        public Guid UserId { get; private set; }
        public DateTime ViewDate { get; private set; }

        public TopicViews(Guid topicId, Guid userId)
        {
            TopicId = topicId;
            UserId = userId;
            ViewDate = DateTime.Now;
        }

        public void UpdateUserView(Guid userId)
        {
            UserId = userId;
        }

        public void UpdateTopicView(Guid topicId)
        {
            TopicId = topicId;
        }

    }
}
