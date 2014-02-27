using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Äventyrliga_Kontakter.Model
{
    public class Contact
    {
        public int ContactID { get; set; }
        
        [Required(ErrorMessage="Ett förnamn måste anges!")]
        [StringLength(50, ErrorMessage="Förnamnet får bestå av 50 tecken som mest!")]
        public string FirstName { get; set; }

       
        [Required(ErrorMessage = "Ett efternamn måste anges")]
        [StringLength(50, ErrorMessage = "Efternamnet får bestå av 50 tecken som mest!")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "En emailadress måste anges")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Felaktigt format för emailadress!")]   
        public string EmailAddress { get; set; }

        


       

    }
}