using System;
using System.Collections.Generic;

namespace Forum.Application.DTO.Identity
{
    public class UserTokenDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }
        public bool Active { get; set; }

        public DateTime CreateDate { get; set; }
        public string ImageProfile { get; set; }
        public int UserTypeId { get; set; }
        public bool IsAdminOrModer { get; set; }
        public bool HasSubscription { get; set; }
        public IEnumerable<ClaimDTO> Claims { get; set; }
    }
}
