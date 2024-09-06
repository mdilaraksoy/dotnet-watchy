using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace watchyproject.Models
{
    public class LoginViewModel
    {
        [Key]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
