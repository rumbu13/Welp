using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class OrderItem
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public int OrderId { get; set; }

        [ForeignKey(nameof(OrderId))]
        public Order Order { get; set; }

        public string WelperProfileId { get; set; }

        [ForeignKey(nameof(WelperProfileId))]
        [Required(ErrorMessage = "Tehnicianul este obligatoriu")]
        [Display(Name = "Client", Description = "Tehnicianul care prestează serviciile")]
        public Profile Client { get; set; }

        [Required(ErrorMessage = "Precizarea stării este obligatorie")]
        [Display(Name = "Stare", Description = "Starea în care se află comanda")]
        public OrderState State { get; set; }

        [Required(ErrorMessage = "Precizarea stării este obligatorie")]
        [Display(Name = "Preț", Description = "Prețul contractat")]
        public decimal Price { get; set; }

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

        [Display(Name = "Notă", Description = "Gradul de satisfacție în prestarea serviciului")]
        [Range(0, 5, ErrorMessage = "Gradul de satisfacție trebuie să fie între 0 și 5")]
        public int Rating { get; set; }

    }
}
