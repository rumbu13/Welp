using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class InvoiceData
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public string ProfileId { get; set; }

        [ForeignKey(nameof(ProfileId))]
        [Display(AutoGenerateField = false)]
        public Profile Profile { get; set; }

        [Display(AutoGenerateField = false)]
        public int LocalityId { get; set; }

        [ForeignKey(nameof(LocalityId))]
        [Display(Name = "Localitate", Description = "Localitatea")]
        [Required(ErrorMessage = "Localitatea este obligatorie")]
        public Locality Locality { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele persoanei sau firmei este obligatoriu")]
        [Display(Name = "Nume", Description = "Numele persoanei sau firmei")]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele persoanei de contact este obligatoriu")]
        [Display(Name = "Contact", Description = "Numele persoanei de contact")]
        public string Contact { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Textul adresei este obligatoriu")]
        [Display(Name = "Adresa", Description = "Adresa completă")]
        public string Address { get; set; }

        [Display(Name = "Cod fiscal", Description = "Codul fiscal")]
        public string TaxCode { get; set; }

        [Display(Name = "Registrul Comerțului", Description = "Număr de înregistrare la Registrul Comerțului")]
        public string RegistrationNo { get; set; }

        [Display(Name = "Cont bancar", Description = "Număr de cont")]
        public string Account { get; set; }

        [Display(Name = "Bancă", Description = "Banca")]
        public string Bank { get; set; }

        [Display(Name = "Adresă principală", Description = "Indică faptul că aceasta este adresa principală de facturare")]
        public bool IsDefault { get; set; }

        [Display(Name = "Nu plătește TVA", Description = "Indică faptul că nu se plătește TVA")]
        public bool VATFree { get; set; }

        [Display(Name = "TVA la încasare", Description = "Indică faptul că se plătește TVA la încasare")]
        public bool VATOnCash { get; set; }



    }
}
