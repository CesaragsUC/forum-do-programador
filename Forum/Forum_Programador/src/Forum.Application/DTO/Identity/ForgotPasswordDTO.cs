using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTO.Identity
{
    public class ForgotPasswordDTO
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
