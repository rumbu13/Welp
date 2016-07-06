using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Adresa de e-mail este neapărat necesară")]
        [EmailAddress(ErrorMessage = "Adresă de e-mail incorectă")]
        [Display(Name = "E-mail", Description = "Adresa de poștă electronică")]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Parola este obligatorie")]
        [DataType(DataType.Password)]
        [Display(Name = "Parola")]
        public string Password { get; set; }

        [Display(Name = "Ține-mă minte", Description = "Bifați dacă doriți să fiți autentificat automat")]
        public bool RememberMe { get; set; }
    }
}
