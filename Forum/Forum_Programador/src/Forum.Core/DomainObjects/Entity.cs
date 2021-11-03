using Forum.Core.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.DomainObjects
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public Entity()
        {
            Id = Guid.NewGuid();
        }

        private List<Event> _notifications;

        private IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();

        public void AddEvent(Event _event)
        {
            _notifications = _notifications ?? new List<Event>();
            _notifications.Add(_event);
        }

        public void RemoveEvent(Event eventItem)
        {
            _notifications?.Remove(eventItem);
        }

        public void ClearEvents()
        {
            _notifications?.Clear();
        }


        public virtual bool IsValid()
        {
            throw new NotFiniteNumberException();
        }
    }
}
