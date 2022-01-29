using Forum.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Forum.Domain.Entities
{
    public class PrivateMessages : Entity, IAggregateRoot
    {

        public Guid SenderId { get; private set; }
        public Guid RecipientId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsSeen { get; private set; }
        public bool SenderCommentsNotReaded { get; private set; }
        public bool RecipientCommentsNotReaded { get; private set; }
        public bool IsReplied { get; set; }
        public string Subject { get; private set; }
        public User Recipient { get; private set; }
        public User Sender { get; private set; }

        private  List<MessageComment> _messageComments;
        public IReadOnlyCollection<MessageComment> MessageComments => _messageComments;


        public PrivateMessages(Guid senderId,Guid recipientId,string subject)
        {
            SenderId = senderId;
            RecipientId = recipientId;
            Subject = subject;
            IsReplied = false;

            _messageComments = new List<MessageComment>();
        }
        protected PrivateMessages()
        {
            _messageComments = new List<MessageComment>();
        }
        
        public void SetIsSeen()
        {
            IsSeen = true;
        }
        public void SetSenderCommentsReaded()
        {
            SenderCommentsNotReaded = false;
        }
        public void SetRecipientCommentsReaded()
        {
            RecipientCommentsNotReaded = false;
        }

        public void SetSenderCommentsNotReaded()
        {
            SenderCommentsNotReaded = true;
        }
        public void SetRecipientCommentsNotReaded()
        {
            RecipientCommentsNotReaded = true;
        }

        public void RemoveIsSeen()
        {
            IsSeen = false;
        }


        public void SetIsReplied()
        {
            IsReplied = true;
        }

        public void AddCommnet(MessageComment coment)
        {
            _messageComments.Add(coment);
        }
    }
}
