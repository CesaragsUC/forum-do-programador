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
        public string Text { get;  set; }
        public Guid UserId { get;  set; }
        public Guid TopicId { get;  set; }
        public DateTime CreationDate { get;  set; }

        public int Point { get; set; }
        public Guid? UserSendPointId { get;  set; }
        public int CommentId { get;  set; }
        public string TimeAgo { get; set; }
        public bool CanEdit { get; set; }

        //EF Realtionship 1:1
        public UserDTO User { get;  set; }

        //EF Realtionship 1:1
        public TopicDTO Topic { get;  set; }

        //EF Realtionship 1:1
        public RankingDTO Ranking { get; set; }
    }

}
