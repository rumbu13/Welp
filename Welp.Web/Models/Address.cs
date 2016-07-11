using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{

    public class Address
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public string ProfileId { get; set; }


        [ForeignKey(nameof(ProfileId))]
        [Display(AutoGenerateField = false)]
        public Profile Profile { get; set; }

        [Display(AutoGenerateField = false)]
        public int LocalityId { get; set; }

        [ForeignKey(nameof(LocalityId))]
        [Display(Name = "Localitate", Description = "Localitatea")]
        [Required(ErrorMessage = "Localitatea este obligatorie")]
        public Locality Locality { get; set; }

        [Display(Name = "Latitudine", Description = "Latitudine")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public double Latitude { get; set; }

        [Display(Name = "Longitudine", Description = "Latitudine")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public double Longitude { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele persoanei de contact este obligatoriu")]
        [Display(Name = "Contact", Description = "Numele persoanei de contact")]
        public string Contact { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Textul adresei este obligatoriu")]
        [Display(Name = "Adresa", Description = "Adresa completă")]
        public string Text { get; set; }

        [Display(Name = "Adresă principală", Description = "Indică faptul că aceasta este adresa principală de contact")]
        public bool IsDefault { get; set; }

    }
}
