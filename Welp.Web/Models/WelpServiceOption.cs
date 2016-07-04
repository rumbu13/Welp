using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public enum WelpServiceOptionType 
    {
        Text,
        Checkbox,
        Dropdown,
    }

    public class WelpServiceOption
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public int WelpServiceId { get; set; }

        [Display(AutoGenerateField = false)]
        [ForeignKey(nameof(WelpServiceId))]
        public WelpService Service { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Textul este obligatoriu")]
        [MaxLength(100, ErrorMessage = "Lungimea maximă a textului este de 100 de caractere")]
        [Display(Name = "Text", Description = "Denumirea opțiunii")]
        public string Text { get; set; }

        [Display(Name = "Descriere", Description = "Descrierea opțiunii")]
        public string Description { get; set; }

        [Display(Name = "Tip", Description = "Tipul opțiunii")]
        public WelpServiceOptionType Type { get; set; }

        [Display(Name = "Sumă fixă", Description = "Suma cu care se majorează sau se micșorează prețul serviciului")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        public decimal? IncreaseOrDecreaseFixed { get; set; }

        [Display(Name = "Procent", Description = "Procentul cu care se majorează sau se micșorează prețul serviciului")]
        [DisplayFormat(DataFormatString = "{0:F0}")]
        [Range(0, 100, ErrorMessage = "Valoarea trebuie să fie cuprinsă între 0 și 100")]
        public decimal? IncreaseOrDecreasePercent { get; set; }

        [Display(Name = "La distanță", Description = "Indică dacă serviciul poate fi prestat la distanță")]
        public bool CanBePerformedOnline { get; set; }

        public ICollection<WelpServiceOptionDropItem> DropDownItems {get; set;}

        
    }
}
