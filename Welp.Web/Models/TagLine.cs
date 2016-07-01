using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class TagLine
    {
        [Key, Required]
        public int Id { get; set; }

        [Required, StringLength(50, MinimumLength = 10)]
        public string Text { get; set; }

        [Required, Range(1, 100)]
        public int Probability { get; set; }
    }
}
