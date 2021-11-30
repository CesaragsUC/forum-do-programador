using System.ComponentModel.DataAnnotations;

namespace Forum.Application.DTO.Identity
{
    public class UseResetPasswordDTO
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]

        [Required(ErrorMessage ="The name is required")]
        public string Name { get; set; }
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "The Email is required")]
        public string Email { get; set; }
        public string Token { get; set; }
    }
}
