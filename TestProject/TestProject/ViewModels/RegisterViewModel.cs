using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestProject.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Name { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public string Login { get; set; }

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
