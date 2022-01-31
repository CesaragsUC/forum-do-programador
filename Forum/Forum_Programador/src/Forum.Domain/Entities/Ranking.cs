using Forum.Core.DomainObjects;
using System;

namespace Forum.Domain.Entities
{
    public class Ranking: Entity, IAggregateRoot
    {
        public Guid UserId { get; private set; }

        public Guid UserSentId { get; private set; }
        public int Point { get; private set; }
        public Guid TopicId { get; private set; }

        public Guid CommentId { get; private set; }

        public DateTime CreationDate { get; private set; }


        protected Ranking()
        {

        }
        public Ranking(Guid userId,Guid userGivePointId,Guid topicId,Guid commentId)
        {
            UserId = userId;
            UserSentId = userGivePointId;
            TopicId = topicId;
            CommentId = commentId;
        }

        public void AddPoint()
        {
            Point ++;
        }

        public void RemovePoint()
        {
            Point--;
        }

    }
}
