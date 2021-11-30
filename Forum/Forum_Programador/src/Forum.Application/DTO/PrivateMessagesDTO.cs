using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class PrivateMessagesDTO
    {
        public Guid Id { get;  set; }
        public Guid SenderId { get;  set; }
        public Guid RecipientId { get;  set; }
        public DateTime CreationDate { get;  set; }
        public bool IsSeen { get;  set; }
        public string Subject { get;  set; }
        public string Text { get;  set; }
        public UserDTO Recipient { get;  set; }
        public UserDTO Sender { get;  set; }

    }
}
