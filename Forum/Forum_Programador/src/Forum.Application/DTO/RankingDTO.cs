using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Application.DTO
{
    public class RankingDTO
    {
        public Guid Id { get; set; }

        public Guid UserId { get;  set; }

        public Guid UserSentPointId { get;  set; }
        public int Point { get;  set; }
        public Guid TopicId { get;  set; }

        public int CommentId { get;  set; }

        public DateTime CreationDate { get;  set; }
    }
}
