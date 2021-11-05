﻿using Forum.Core.DomainObjects;
using System;

namespace Forum.Domain.Entities
{
    public class Section : Entity, IAggregateRoot
    {
        public string Name { get; private set; }
        public bool IsActive { get; private set; }

        public DateTime CreationDate { get; set; }

        public Section( string name,bool active)
        {
            Name = name;
            IsActive = active;
        }
        protected Section()
        {

        }
    }
}
