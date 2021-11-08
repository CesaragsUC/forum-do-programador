using Forum.Core.DomainObjects;

namespace Forum.Domain.Entities
{
    public class Area : Entity,IAggregateRoot
    {

        public string Name { get; private set; }
        protected Area()
        {

        }
        public Area(string name)
        {
            Name = name;
        }

        public void UpdateName(string name)
        {
            Name = name;
        }
    }
}
