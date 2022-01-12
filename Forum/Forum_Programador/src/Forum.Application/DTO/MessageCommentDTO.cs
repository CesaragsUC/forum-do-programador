using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class MessageCommentDTO
    {
        public Guid Id { get;  set; }

        public Guid UserId { get;  set; }
        public Guid PrivateMessageId { get;  set; }
        public DateTime CreationDate { get;  set; }
        public bool IsSeen { get;  set; }
        public string Text { get;  set; }
        public UserDTO User { get;  set; }

        public PrivateMessagesDTO PrivateMessages { get; set; }
        public string TimeAgo { get; set; }
    }
}
