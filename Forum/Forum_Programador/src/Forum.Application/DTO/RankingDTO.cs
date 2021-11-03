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

        public Guid UserId { get; private set; }

        public Guid UserSentPointId { get; private set; }
        public int Point { get; private set; }
        public Guid TopicId { get; private set; }

        public int CommentId { get; private set; }

        public DateTime CreationDate { get; private set; }
    }
}
