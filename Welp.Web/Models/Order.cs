using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{

    


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
       

        [Required(ErrorMessage = "Precizarea stării este obligatorie")]
        [Display(Name = "Preț total", Description = "Prețul contractat")]
        public decimal TotalPrice { get; set; }

        [Display(Name = "La distanță", Description = "Indică dacă serviciile sunt prestate la distanță")]
        public bool IsOnline { get; set; }

        public ICollection<OrderItem> Items { get; set; }

        [Required(ErrorMessage = "Precizarea datei este obligatorie")]
        [Display(Name = "Data solicitării", Description = "Data și ora când a fost solicitat serviciul")]
        public DateTime RequestTimestamp { get; set; }

    }
}
