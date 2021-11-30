using System;

namespace Forum.Application.DTO
{
    public class TopicViewsDTO
    {
        public Guid Id { get; set; }

        public Guid TopicId { get;  set; }
        public Guid UserId { get;  set; }
        public DateTime ViewDate { get;  set; }
    }
}
