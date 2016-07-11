using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{

    public enum WelperInvoiceState
    {
       Draft,       
       Accepted,
       Rejected,
       Reversed,
       Payed,
    }

    public class WelperInvoiceStateHistory
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public int InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public WelperInvoice Invoice { get; set; }

        [Required(ErrorMessage = "Precizarea stării este obligatorie")]
        [Display(Name = "Stare", Description = "Starea în care se află factura")]
        public WelperInvoiceState State { get; set; }

        [Required(ErrorMessage = "Precizarea datei și orei este obligatorie")]
        [Display(Name = "Dată și oră", Description = "Momentul în care starea curentă a devenit activă")]
        public DateTime Timestamp { get; set; }

    }
}
