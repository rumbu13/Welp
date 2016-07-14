using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class WelpService
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Textul este obligatoriu")]
        [MaxLength(150, ErrorMessage = "Lungimea maximă a textului este de 150 de caractere")]
        [Display(Name = "Text", Description = "Denumirea serviciului")]
        public string Text { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Titlul este obligatoriu")]
        [Display(Name = "Titlu", Description = "Titlul serviciului")]
        public string Title { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Textul este obligatoriu")]
        [Display(Name = "Descriere", Description = "Descrierea serviciului")]
        public string Description { get; set; }

        [Display(AutoGenerateField = false)]
        public int WelpServiceCategoryId { get; set; }

        [ForeignKey(nameof(WelpServiceCategoryId))]
        public WelpServiceCategory Category { get; set; }

        [Required(ErrorMessage = "Prețul serviciului este obligatoriu")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Display(Name = "Preț", Description = "Prețul serviciului")]
        public decimal Price { get; set; }

        [Display(Name = "La distanță", Description = "Indică dacă serviciul poate fi prestat la distanță")]
        public bool CanBePerformedOnline { get; set; }

        [Display(Name = "Discount la distanță", Description = "Reducere de preț pentru prestarea serviciului la distanță")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal OnlineDiscount { get; set; }
        
        [Display(Name = "Iconiță mică", Description = "Numele fișierului care reprezintă iconița de mărime mică")]
        [DataType(DataType.ImageUrl)]
        public string SmallIcon { get; set; }

        [Display(Name = "Iconiță medie", Description = "Numele fișierului care reprezintă iconița de mărime medie")]
        [DataType(DataType.ImageUrl)]
        public string MediumIcon { get; set; }

        [Display(Name = "Iconiță mare", Description = "Numele fișierului care reprezintă iconița de mărime mare")]
        [DataType(DataType.ImageUrl)]
        public string LargeIcon { get; set; }

        [Display(Name = "Servicii incluse", Description = "Lista de servicii incluse, câte unul pe fiecare linie")]
        public string IncludedPrestations { get; set; }

        [Display(Name = "Durata standard", Description = "Durata standard exprimată în minute în care se presupune că poate fi prestat serviciul")]
        public int StandardDuration { get; set; }


        public ICollection<WelpServiceOption> Options { get; set; }
    }
}
