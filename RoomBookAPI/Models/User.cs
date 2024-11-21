using System.ComponentModel.DataAnnotations;

namespace RoomBookAPI.Models
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [MinLength(6), MaxLength(18)]
        public string Password { get; set; } = string.Empty;
        [Required]
        public string Role { get; set; } = "User"; // Admin, Manager and User
    }
}