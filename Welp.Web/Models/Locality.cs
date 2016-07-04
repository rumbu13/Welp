using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class Locality
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public int Id { get; set; }

        [Display(AutoGenerateField = false)]
        public int CountyId { get; set; }
        [ForeignKey(nameof(CountyId))]
        public County County { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Numele localității este obligatoriu")]
        [Display(Name = "Nume", Description = "Numelele localității")]
        public string Name { get; set; }

        [Display(Name = "Latitudine", Description = "Latitudine")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public double Latitude { get; set; }

        [Display(Name = "Longitudine", Description = "Latitudine")]
        [DisplayFormat(DataFormatString = "{0:F}")]
        public double Longitude { get; set; }


    }
}
