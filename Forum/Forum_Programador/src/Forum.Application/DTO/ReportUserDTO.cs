using System;

namespace Forum.Application.DTO
{
    public class ReportUserDTO
    {
        public Guid UserSendReportId { get;  set; }
        public Guid UserId { get;  set; }
        public string Reason { get;  set; }
        public DateTime CreationDate { get;  set; }
    }
}
