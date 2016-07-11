using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class WelperInvoiceItem
    {
        [Key]
        [Display(AutoGenerateField = false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int InvoiceId { get; set; }

        [ForeignKey(nameof(InvoiceId))]
        public WelperInvoice Invoice { get; set; }

        public int OrderItemId { get; set; }

        [ForeignKey(nameof(OrderItemId))]
        public OrderItem OrderItem { get; set; }

        [Required(ErrorMessage = "Descrierea este obligatorie")]
        [Display(Name = "Descriere", Description = "Descrierea serviciului prestat")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Valoarea netă este obligatorie")]
        [Display(Name = "Net", Description = "Valoarea netă serviciului prestat")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Net { get; set; }

        [Required(ErrorMessage = "Valoarea TVA este obligatorie")]
        [Display(Name = "TVA", Description = "Valoarea TVA aferentă serviciului prestat")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal VAT { get; set; }

        [Required(ErrorMessage = "Valoarea brută este obligatorie")]
        [Display(Name = "TVA", Description = "Valoarea brută aferentă serviciului prestat")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal Gross { get; set; }
    }
}
