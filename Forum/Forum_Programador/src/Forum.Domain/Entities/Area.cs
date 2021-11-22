using Forum.Core.DomainObjects;
using System.Collections;
using System.Collections.Generic;

namespace Forum.Domain.Entities
{
    public class Area : Entity,IAggregateRoot
    {

        public string Name { get; private set; }

        //EF 1:1
        public List<Section> Sections { get; private set; }

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
