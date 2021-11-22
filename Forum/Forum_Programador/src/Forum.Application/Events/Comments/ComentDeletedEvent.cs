using Forum.Core.Messages;
using System;

namespace Forum.Application.Events.Comments
{
    public class ComentDeletedEvent : Event
    {
        public Guid CommentId { get;private set; }
        public Guid UserDeleteId { get; private set; }
        public Guid TopicId { get; private set; }
        public DateTime DeleteDate { get; private set; }

        public ComentDeletedEvent(Guid commentId,Guid userdeleteId,Guid topicId)
        {
            CommentId = commentId;
            UserDeleteId = userdeleteId;
            TopicId = topicId;
            DeleteDate = TimeStamp;

        }
    }
}
