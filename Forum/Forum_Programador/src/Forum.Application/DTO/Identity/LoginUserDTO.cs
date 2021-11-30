using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTO.Identity
{
    public class LoginUserDTO
    {
        public string UserName { get; set; }
        public string Email { get; set; }

        [Required(ErrorMessage = "The {0} is required")]
        [StringLength(100, ErrorMessage = "the {0} password should have between {2} and {1} characters", MinimumLength = 6)]
        public string Password { get; set; }
    }
}
