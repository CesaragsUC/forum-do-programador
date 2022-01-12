using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Forum.Core.DomainObjects;

namespace Forum.Domain.Entities
{
    public class MessageComment : Entity, IAggregateRoot
    {
        public Guid UserId { get;  private set; }
        public Guid PrivateMessageId { get; private set; }
        public DateTime CreationDate { get; private set; }
        public bool IsSeen { get; private set; }
        public string Text { get; private set; }
        public User User { get; private set; }

        public PrivateMessages PrivateMessages { get; set; }

        public MessageComment(Guid userId,Guid messageId, string text)
        {
            PrivateMessageId = messageId;
            UserId = userId;
            Text = text;
            IsSeen = false;
            CreationDate =  DateTime.Now;
        }

        protected MessageComment()
        {

        }

        public void MessageSeen()
        {
            IsSeen = true;
        }
    }
}
