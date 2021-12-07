using SharpBank.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SharpBank.API.DTOs.Account
{
    public class UpdateAccountDTO
    {
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"^[\S]{8,}$", ErrorMessage = "Atleast 8 characters, no whitespace")]
        public string Password { get; set; }
        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        public string ConfirmPassword { get; set; }
        public Gender Gender { get; set; }
        public Status Status { get; set; }
    }
}
