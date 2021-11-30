using System;
using System.Collections.Generic;

namespace Forum.Application.DTO
{
    public class TopicDTO
    {
        public Guid Id { get; set; }

        public string Title { get;  set; }

        public Guid UserId { get;  set; }
        public Guid SectionId { get; set; }

        public int TotalViews { get;  set; }

        public int TotalReplies { get; set; }

        public string LastCommentTimeAgo { get; set; }

        public DateTime CreationDate { get;  set; }

        public UserDTO User { get;  set; }

        public UserDTO UserLastPost { get; set; }


        public ICollection<CommentsDTO> Coments { get;  set; }
    }
}
