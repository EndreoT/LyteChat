
using System.ComponentModel.DataAnnotations;

namespace LyteChat.Shared.DataTransferObject
{
    public class RegisterModel
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        public string UserName { get; set; }

        [MinLength(6)]
        [Required]
        public string Password { get; set; }
    }
}
