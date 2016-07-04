using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class County
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele județului este obligatoriu")]
        [Display(Name = "Nume", Description = "Numelele județului")]
        public string Name { get; set; }

        public ICollection<Locality> Localities { get; set; }
    }
}
