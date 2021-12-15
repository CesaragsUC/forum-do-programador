using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTO
{
    public class UpdateUserAvatarDTO
    {
        public Guid Id { get; set; }

        public Guid IdentityId { get; set; }

        [Required(ErrorMessage = "The field {0} is required.")]
        public IFormFile AvatarUpload { get; set; }

        [Required(ErrorMessage ="The field {0} is required.")]
        public string Avatar { get; set; }

    }
}
