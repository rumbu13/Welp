using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public enum FAQType
    {
        Client,
        Welper,
        Both,
    }


    public class FAQ
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }
        
        [Display(AutoGenerateField = false)]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        [Display(Name = "Categorie", Description = "Categoria din care face parte întrebarea")]
        public FAQCategory Category { get; set; }

        [Required(ErrorMessage = "Tipul este obligariu")]
        [Display(Name = "Tip", Description = "Pentru cine e răspunsul")]
        public FAQType Type { get; set; }

        [Required(ErrorMessage = "Întrebarea este obligatorie")]
        [Display(Name = "Întrebare", Description = "Întrebare frecventă")]
        public string Question { get; set; }

        [Required(ErrorMessage = "Răspunsul este obligatoriu")]
        [Display(Name = "Răspuns", Description = "Răspunsul la întrebarea frecventă")]
        public string Answer { get; set; }
    }
}
