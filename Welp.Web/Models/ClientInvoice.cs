using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{


    public class ClientInvoice
    {
        [Key]
        [Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string ClientId { get; set; }

        [ForeignKey(nameof(ClientId))]
        public Profile Client { get; set; }

        [Required(ErrorMessage = "Precizarea stării este obligatorie")]
        [Display(Name = "Stare", Description = "Starea în care se află factura")]
        public ClientInvoiceState LastState { get; set; }



        [Display(AutoGenerateField = false)]
        public int ProviderLocalityId { get; set; }

        [ForeignKey(nameof(ProviderLocalityId))]
        [Display(Name = "Localitate", Description = "Localitatea")]
        [Required(ErrorMessage = "Localitatea este obligatorie")]
        public Locality ProviderLocality { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele persoanei sau firmei este obligatoriu")]
        [Display(Name = "Nume", Description = "Numele persoanei sau firmei")]
        public string ProviderName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele persoanei de contact este obligatoriu")]
        [Display(Name = "Contact", Description = "Numele persoanei de contact")]
        public string ProviderContact { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Textul adresei este obligatoriu")]
        [Display(Name = "Adresa", Description = "Adresa completă")]
        public string ProviderAddress { get; set; }

        [Display(Name = "Cod fiscal", Description = "Codul fiscal")]
        public string ProviderTaxCode { get; set; }

        [Display(Name = "Registrul Comerțului", Description = "Număr de înregistrare la Registrul Comerțului")]
        public string ProviderRegistrationNo { get; set; }

        [Display(Name = "Cont bancar", Description = "Număr de cont")]
        public string ProviderAccount { get; set; }

        [Display(Name = "Bancă", Description = "Banca")]
        public string ProviderBank { get; set; }

        public ICollection<ClientInvoiceItem> InvoiceItems { get; set; }

        public ICollection<ClientInvoiceStateHistory> History { get; set; }

        public int? ReverseInvoiceId {get; set;}

        [ForeignKey(nameof(ReverseInvoiceId))]
        public ClientInvoice ReverseInvoice { get; set; }

        public int InvoiceDataId { get; set; }

        [ForeignKey(nameof(InvoiceDataId))]
        public InvoiceData InvoiceData { get; set; }

        public DateTime Date { get; set; }
        public DateTime DueDate { get; set; }

        public decimal TotalNet { get; set; }
        public decimal TotalVAT { get; set; }
        public decimal TotalGross { get; set; }
    }
}
