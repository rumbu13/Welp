using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class FAQCategory
    {

        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Precizarea categoriei este obligatorie")]
        [Display(Name = "Text", Description = "Categoria din care face parte întrebarea")]
        public string Text { get; set; }

        [Display(Name = "Iconiță", Description = "Clasa html care reprezinta iconița")]
        public string Icon { get; set; }

        public ICollection<FAQ> FAQs { get; set; }
    }
}
