using Forum.Core.DomainObjects;
using System;

namespace Forum.Domain.Entities
{
    public class PrivateMessages : Entity, IAggregateRoot
    {

        public Guid SenderId { get; private set; }
        public Guid RecipientId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsSeen { get; private set; }
        public string Subject { get; private set; }
        public string Text { get; private set; }
        public User Recipient { get; private set; }
        public User Sender { get; private set; }


        public PrivateMessages(Guid senderId,Guid recipientId,string subject,string text)
        {
            SenderId = senderId;
            RecipientId = recipientId;
            Subject = subject;
            Text = text;
        }
        protected PrivateMessages()
        {

        }
        
        public void MessageSeen()
        {
            IsSeen = true;
        }
        
    }
}
