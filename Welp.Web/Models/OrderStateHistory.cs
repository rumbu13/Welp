using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public enum OrderState
    {
        InShoppingCart,
        Ordered,
        Payed,
        Assigned,
        InProgress,
        Performed,
        Rejected,
        Reimbursed,
        Accepted,
        PayedToWelper,
    }

    public class OrderStateHistory
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public int OrderItemId { get; set; }

        [ForeignKey(nameof(OrderItemId))]
        public OrderItem OrderItem { get; set; }

        [Required(ErrorMessage = "Precizarea stării este obligatorie")]
        [Display(Name = "Stare", Description = "Starea în care se află comanda")]
        public OrderState State { get; set; }
        
        [Required(ErrorMessage = "Precizarea datei și orei este obligatorie")]
        [Display(Name = "Dată și oră", Description = "Momentul în care starea curentă a devenit activă")]
        public DateTime Timestamp { get; set; }


    }
}
