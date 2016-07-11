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

        [MaxLength(40, ErrorMessage = "Lungimea maximă a numărului de telefon este de 40 de caractere")]
        [Display(Name = "Telefon", Description = "Telefonul de contact")]
        public string PhoneNo { get; set; }

        [Display(Name = "Data nașterii", Description = "Data nașterii")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Poză", Description = "Poza utilizatorului")]
        public byte[] Picture { get; set; }
        
        public ICollection<Address> Addresses { get; set; }

        public ICollection<InvoiceData> InvoiceDatas { get; set; }

        [Display(Name = "Latitudine", Description = "Ultima latitudine la care a fost prezent utilizatorul")]
        public double LastKnownLatitude { get; set; }

        [Display(Name = "Longitudine", Description = "Ultima longitudine la care a fost prezent utilizatorul")]
        public double LastKnownLongitude { get; set; }

        [Display(Name = "Moment", Description = "Ultimul moment la care a fost actualizată locația utilizatorului")]
        public DateTime LastKnownTimestamp { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<ClientInvoice> ClientInvoices { get; set; }
        public ICollection<WelperInvoice> WelperInvoices { get; set; }
        public ICollection<OrderItem> Jobs { get; set; }


    }
}
