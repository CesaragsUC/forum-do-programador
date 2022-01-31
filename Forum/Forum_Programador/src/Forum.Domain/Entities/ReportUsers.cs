using Forum.Core.DomainObjects;
using System;

namespace Forum.Domain.Entities
{
    public class ReportUsers : Entity, IAggregateRoot
    {

        public Guid UserSendReportId { get; private set; }
        public Guid UserId { get; private set; }
        public string Reason { get; private set; }
        public DateTime CreationDate { get; private set; }


        public ReportUsers(Guid userSendId,Guid userId,string reason)
        {
            UserSendReportId = userSendId;
            UserId = userId;
            Reason = reason;
        }

        protected ReportUsers()
        {
                
        }
    }
}
