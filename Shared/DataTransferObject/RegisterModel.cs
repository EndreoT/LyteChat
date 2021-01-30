
using System.ComponentModel.DataAnnotations;

namespace LyteChat.Shared.DataTransferObject
{
    public class RegisterModel
    {
        [EmailAddress]
        [Required]
        [MinLength(1)]
        public string Email { get; set; }

        [Required]
        [MinLength(1)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [RegularExpression(
            @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*])[A-Za-z\d!@#$%^&*]{6,20}",
            ErrorMessage = "Passwords must be at least 6 characters, have at least one non alphanumeric character, have at least one digit ('0'-'9'), and have at least one uppercase ('A'-'Z').")]
        public string Password { get; set; }
    }
}
