using Microsoft.AspNetCore.Http;
using System;

namespace Forum.Application.DTO
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        public Guid IdentityId { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }

        public IFormFile AvatarUpload { get; set; }
        public string Avatar { get;  set; }

        public int UserTypeId { get;  set; }

        public DateTime CreationDate { get;  set; }

        public DateTime LastActivity { get;  set; }
    }
}
