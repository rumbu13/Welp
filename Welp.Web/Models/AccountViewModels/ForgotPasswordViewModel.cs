﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Adresa de e-mail este neapărat necesară")]
        [EmailAddress(ErrorMessage = "Adresă de e-mail incorectă")]
        [Display(Name = "E-mail", Description = "Adresa de poștă electronică")]
        public string Email { get; set; }
    }
}
