using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{


    public class WelperInvoice
    {
        [Key]
        [Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string WelperId { get; set; }

        [ForeignKey(nameof(WelperId))]
        public Profile Welper { get; set; }

        [Required(ErrorMessage = "Precizarea stării este obligatorie")]
        [Display(Name = "Stare", Description = "Starea în care se află factura")]
        public WelperInvoiceState LastState { get; set; }



        [Display(AutoGenerateField = false)]
        public int ClientLocalityId { get; set; }

        [ForeignKey(nameof(ClientLocalityId))]
        [Display(Name = "Localitate", Description = "Localitatea")]
        [Required(ErrorMessage = "Localitatea este obligatorie")]
        public Locality ClientLocality { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele persoanei sau firmei este obligatoriu")]
        [Display(Name = "Nume", Description = "Numele persoanei sau firmei")]
        public string ClientName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele persoanei de contact este obligatoriu")]
        [Display(Name = "Contact", Description = "Numele persoanei de contact")]
        public string ClientContact { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Textul adresei este obligatoriu")]
        [Display(Name = "Adresa", Description = "Adresa completă")]
        public string ClientAddress { get; set; }

        [Display(Name = "Cod fiscal", Description = "Codul fiscal")]
        public string ClientTaxCode { get; set; }

        [Display(Name = "Registrul Comerțului", Description = "Număr de înregistrare la Registrul Comerțului")]
        public string ClientRegistrationNo { get; set; }

        [Display(Name = "Cont bancar", Description = "Număr de cont")]
        public string ClientAccount { get; set; }

        [Display(Name = "Bancă", Description = "Banca")]
        public string ClientBank { get; set; }

        public ICollection<WelperInvoiceItem> InvoiceItems { get; set; }

        public ICollection<WelperInvoiceStateHistory> History { get; set; }

        public int? ReverseInvoiceId {get; set;}

        [ForeignKey(nameof(ReverseInvoiceId))]
        public WelperInvoice ReverseInvoice { get; set; }

        public int InvoiceDataId { get; set; }

        [ForeignKey(nameof(InvoiceDataId))]
        public InvoiceData InvoiceData { get; set; }

        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public decimal TotalNet { get; set; }
        public decimal TotalVAT { get; set; }
        public decimal TotalGross { get; set; }

        public bool VATFree { get; set; }
        public bool VATOnCash { get; set; }
    }
}
