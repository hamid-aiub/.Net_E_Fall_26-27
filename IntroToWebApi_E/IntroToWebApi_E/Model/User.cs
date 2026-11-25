using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IntroToWebApi_E.Model
{
    [Table("Users")]
    [Index(nameof(email), IsUnique = true)]
    public class User
    {
        [Key]
        public Guid id { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string  email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string password { get; set; }

        public string? department { get; set; }

        public int? CreditCompleted { get; set; }
    }
}
