using Forum.Core.DomainObjects;

namespace Forum.Domain.Entities
{
    public class Section : Entity, IAggregateRoot
    {
        public string Name { get; private set; }

        public Section( string name)
        {
            Name = name;
        }
        protected Section()
        {

        }
    }
}
