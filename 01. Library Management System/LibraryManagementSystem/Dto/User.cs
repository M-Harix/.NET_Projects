using System.ComponentModel.DataAnnotations;

namespace LibraryManagementSystem.Dto
{
    public class UserDto
    {
        [Required]
        public string Username { get; set; }
        
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*()_+}{""':;/?/>.<,]).{8,}$",
            ErrorMessage = "Password must have at least one number, one letter, one special character, and be at least 8 characters long.")]
        public string Password { get; set; }
        
    }
    public class UserLoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }

    }
}
