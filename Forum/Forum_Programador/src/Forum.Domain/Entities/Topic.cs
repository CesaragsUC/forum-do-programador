using Forum.Core.DomainObjects;
using System;
using System.Collections.Generic;

namespace Forum.Domain.Entities
{
    public class Topic : Entity, IAggregateRoot
    {
        public string Title { get; private set; }

        public Guid UserId { get; private set; }

        public Guid SectionId { get; private set; }

        public int TotalViews { get; private set; }

        public int TotalReplies { get; private set; }

        public DateTime CreationDate { get; private set; }

        //EF Relation 1:1
        public User User { get; private set; }

        //EF Relation 1:1
        public Section Section { get; private set; }


        //EF Relation 1:N
        public ICollection<Comments> Coments { get; private set; }

        public Topic(string title,Guid userId)
        {
            Title = title;
            UserId = userId;
        }

        protected Topic()
        {

        }
    }
}
