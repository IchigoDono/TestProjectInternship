using System.ComponentModel.DataAnnotations;

namespace TasksTracker.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string LastName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Email { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 10)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8)]
        [Compare("Password", ErrorMessage = "Password mismatch")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
    }
}
