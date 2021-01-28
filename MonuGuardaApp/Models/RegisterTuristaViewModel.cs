using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MonuGuardaApp.Models
{
    public class RegisterTuristaViewModel
    {
        [Required]
        [StringLength(128)]
        public string Nome { get; set; }

        [Required]
        [StringLength(256)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Morada { get; set; }
        [Required]
        public int NIF { get; set; }
        [Required]
        public int Telemovel { get; set; }
        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "The passwords don't match")]
        public string ConfirmPassword { get; set; }
    }
}
