using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class WelpServiceCategory
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Textul este obligatoriu")]
        [MaxLength(100, ErrorMessage = "Lungimea maximă a textului este de 100 de caractere")]
        [MinLength(10, ErrorMessage = "Lungimea minimă a textului este de 10 de caractere")]
        [Display(Name = "Text", Description = "Numele categoriei")]
        public string Text { get; set; }

        [Display(Name = "Iconiță mică", Description = "Numele fișierului care reprezintă iconița de mărime mică")]
        [DataType(DataType.ImageUrl)]
        public string SmallIcon { get; set; }

        [Display(Name = "Iconiță medie", Description = "Numele fișierului care reprezintă iconița de mărime medie")]
        [DataType(DataType.ImageUrl)]
        public string MediumIcon { get; set; }

        [Display(Name = "Iconiță mare", Description = "Numele fișierului care reprezintă iconița de mărime mare")]
        [DataType(DataType.ImageUrl)]
        public string LargeIcon { get; set; }

        public ICollection<WelpService> Services { get; set; }

    }
}
