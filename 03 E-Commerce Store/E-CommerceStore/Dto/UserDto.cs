using System.ComponentModel.DataAnnotations;

namespace E_CommerceStore.Dto
{
    public class UserDto
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 8)]
        [RegularExpression(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[!@#$%^&*()_+}{""':;/?/>.<,]).{8,}$",
                           ErrorMessage = "Password must have at least one number, one letter, one special character, and be at least 8 characters long.")]
        public string PasswordHash { get; set; }
        public string Role { get; set; }
        public DateTime DateOfBirth { get; set; }
        // Address
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
