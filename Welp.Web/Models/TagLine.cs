using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class TagLine
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Textul este obligatoriu")]
        [MaxLength(25, ErrorMessage = "Lungimea maximă a textului este de 25 de caractere")]
        [Display(Name = "Text", Description = "Text afișat ca motto")]
        public string Text { get; set; }

        [Required(ErrorMessage = "Probabilitatea este obligatorie")]
        [Range(1, 100, ErrorMessage ="Probabilitatea trebuie să fir cuprinsă între 1 și 100")]
        [Display(Name = "Probabilitate", Description = "Probabilitate de apariție a textului")]
        public int Probability { get; set; }
    }
}
