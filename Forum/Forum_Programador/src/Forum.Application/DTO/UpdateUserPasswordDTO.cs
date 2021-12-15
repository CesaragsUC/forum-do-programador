using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTO
{
    public class UpdateUserPasswordDTO
    {
        public Guid Id { get; set; }

        public Guid IdentityId { get; set; }

        public string OldPassword { get; set; }

        [MinLength(6, ErrorMessage = "Min Password length is {0}")]
        [MaxLength(12,ErrorMessage ="Max Password length is {1}")]
        public string Password { get; set; }
    }
}
