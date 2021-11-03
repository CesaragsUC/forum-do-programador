using Forum.Core.DomainObjects;
using System;

namespace Forum.Domain.Entities
{
    public class Ranking: Entity, IAggregateRoot
    {
        public Guid UserId { get; private set; }

        public Guid UserSentPointId { get; private set; }
        public int Point { get; private set; }
        public Guid TopicId { get; private set; }

        public int CommentId { get; private set; }

        public DateTime CreationDate { get; private set; }


        protected Ranking()
        {

        }
        public Ranking(Guid userId,Guid userGivePointId,int point,Guid topicId,int commentId)
        {
            UserId = userId;
            UserSentPointId = userGivePointId;
            Point = point;
            TopicId = topicId;
            CommentId = commentId;
        }

    }
}
