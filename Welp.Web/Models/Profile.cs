using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Welp.Web.Models
{
    public class Profile
    {
        [Key]
        [Display(AutoGenerateField = false)]
        public string Id { get; set; }

        [MaxLength(150, ErrorMessage = "Lungimea maximă a prenumelui este de 150 de caractere")]
        [Display(Name = "Prenume", Description = "Prenumele")]
        public string FirstName { get; set; }

        [MaxLength(150, ErrorMessage = "Lungimea maximă a numelui este de 150 de caractere")]
        [Display(Name = "Nume", Description = "Numele de familie")]
        public string LastName { get; set; }

        [MaxLength(40, ErrorMessage = "Lungimea maximă a telefonului este de 40 de caractere")]
        [Display(Name = "Telefon", Description = "Telefonul de contact")]
        public string PhoneNo { get; set; }

        [Display(Name = "Data nașterii", Description = "Data nașterii")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Poză", Description = "Poza utilizatorului")]
        public byte[] Picture { get; set; }
        
        public ICollection<Address> Addresses { get; set; }
    }
}
