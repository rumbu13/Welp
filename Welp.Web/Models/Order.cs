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


    public class Order
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        public string ClientProfileId { get; set; }

        [ForeignKey(nameof(ClientProfileId))]
        [Required(ErrorMessage = "Clientul este obligatoriu")]
        [Display(Name = "Client", Description = "Clientul care a solicitat serviciile")]
        public Profile Client { get; set; }


        public string WelperProfileId { get; set; }

        [ForeignKey(nameof(WelperProfileId))]
        [Display(Name = "Welper", Description = "Tehnicianul alocat pentru a presta serviciile")]
        public Profile Welper { get; set; }

        [Required(ErrorMessage = "Precizarea stării este obligatorie")]
        [Display(Name = "Stare", Description = "Starea în care se află comanda")]
        public OrderState State { get; set; }

        [Required(ErrorMessage = "Precizarea stării este obligatorie")]
        [Display(Name = "Preț total", Description = "Prețul contractat")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "La distanță", Description = "Indică dacă serviciile sunt prestate la distanță")]
        public bool IsOnline { get; set; }


        public int DeliveryAddressId { get; set; }

        [ForeignKey(nameof(DeliveryAddressId))]
        [Display(Name = "Adresa", Description = "Adresa unde sunt prestate serviciile")]
        public Address DeliveryAddress { get; set; }

        public int SourceAddressId { get; set; }

        [ForeignKey(nameof(SourceAddressId))]
        [Display(Name = "Adresa sursă", Description = "Adresa de unde sunt prestate serviciile")]
        public Address SourceAddress { get; set; }

    }
}
