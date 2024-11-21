using System.ComponentModel.DataAnnotations;

namespace RoomBookAPI.Dto
{
    public class LoginDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [MinLength(6), MaxLength(18)]
        public string Password { get; set; } = string.Empty;
    }
}