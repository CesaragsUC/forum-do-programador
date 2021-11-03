using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Messages.CommonMessage.DomainEvents
{
    public abstract class DomainEvents : Message, INotification
    {

        public DateTime TimeStamp { get; private set; }

        public DomainEvents(Guid aggregationId)
        {
            AggregateId = aggregationId;
            TimeStamp = DateTime.Now;
        }
    }
}
