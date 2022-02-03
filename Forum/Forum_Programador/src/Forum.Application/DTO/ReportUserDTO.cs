using System;

namespace Forum.Application.DTO
{
    public class ReportUserDTO
    {
        public Guid UserSendReportId { get;  set; }
        public Guid UserId { get;  set; }
        public string Name { get; set; }
        public string Reason { get;  set; }
        public bool IsBanned { get; set; }
        public DateTime CreationDate { get;  set; }
    }
}
