using System;
using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTO
{
    public class UpdateUserPasswordDTO
    {
        public Guid Id { get; set; }

        public Guid IdentityId { get; set; }


        [Required(ErrorMessage = "The {0} is required")]
        public string OldPassword { get; set; }

        [MinLength(6, ErrorMessage = "Min Password length is 6")]
        [MaxLength(12,ErrorMessage ="Max Password length is 12")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
