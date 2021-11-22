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
        private readonly List<Comments> _comments;
        public IReadOnlyCollection<Comments> Coments => _comments;

        public Topic(string title,Guid userId, Guid sectionId)
        {
            Title = title;
            UserId = userId;
            SectionId = sectionId;
            TotalViews = 0;
            TotalReplies = 0;
            _comments = new List<Comments>();

        }

        protected Topic()
        {
            _comments = new List<Comments>();
        }

        public void UpdateTitle(string title)
        {
            Title = title;
        }

        public void UpdateSection(Guid sectionId)
        {
            SectionId = sectionId;
        }

        public void AddCommnet(Comments coment)
        {
            _comments.Add(coment);
        }
    }
}
