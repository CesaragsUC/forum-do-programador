using Forum.Core.DomainObjects;
using System;

namespace Forum.Domain.Entities
{
    public class Comments : Entity ,IAggregateRoot
    {
        public string Text { get; private set; }
        public Guid UserId { get; private set; }
        public Guid TopicId { get; private set; }
        public DateTime CreationDate { get; private set; }

        public int CommentId { get; private set; }

        //EF Realtionship 1:1
        public User User { get; private set; }

        //EF Realtionship 1:1
        public Topic Topic { get; private set; }

        public int Point { get; private set; }
        public Guid? UserSendPointId { get; private set; }

        public Comments(string text,Guid userId,Guid topicId,int commentId)
        {
            Text = text;
            UserId = userId;
            TopicId = topicId;
            CommentId = commentId;
            Point = 0;
        }
        protected Comments()
        {

        } 
        public void UpdateText( string text)
        {
            Text = text;
        }
        public void EncreaCommentId()
        {
            CommentId += 1;
        }
        public void AddPoint()
        {
            Point++;
        }

        public void RemovePoint()
        {
            Point--;
        }

        public void AddUserSentPointId(Guid userSendPointId)
        {
            UserSendPointId = userSendPointId;
        }
    }
}
