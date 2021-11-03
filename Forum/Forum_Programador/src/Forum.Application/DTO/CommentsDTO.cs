using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class CommentsDTO
    {
        public Guid Id { get; set; }
        public string Text { get; private set; }
        public Guid UserId { get; private set; }
        public Guid TopicId { get; private set; }
        public DateTime CreationDate { get; private set; }

        public int CommentId { get; private set; }

        //EF Realtionship 1:1
        public UserDTO User { get; private set; }

        //EF Realtionship 1:1
        public TopicDTO Topic { get; private set; }
    }

}
