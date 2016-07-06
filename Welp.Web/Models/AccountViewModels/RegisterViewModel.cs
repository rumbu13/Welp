using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models.AccountViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Adresa de e-mail este neapărat necesară")]
        [EmailAddress(ErrorMessage = "Adresă de e-mail incorectă")]
        [Display(Name = "E-mail", Description = "Adresa de poștă electronică")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "{0} trebuie să aibă cel puțin {2} caractere și maximum {1} caractere.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmare parolă")]
        [Compare(nameof(Password), ErrorMessage = "Cele două parole introduse nu corespund.")]
        public string ConfirmPassword { get; set; }
    }
}
