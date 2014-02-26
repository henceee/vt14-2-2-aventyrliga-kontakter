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
        [StringLength(50, ErrorMessage="Namnet får bestå av 50 tecken som mest!")]
        public string FirstName { get; set; }

       
        [Required(ErrorMessage = "Ett efternamn måste anges")]
        [StringLength(50, ErrorMessage = "Namnet får bestå av 50 tecken som mest!")]

        public string LastName { get; set; }

        [Required(ErrorMessage = "En emailadress måste anges")]
        [StringLength(50, ErrorMessage = "Adressen får bestå av 50 tecken som mest!")]
        [RegularExpression(@"/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/", ErrorMessage="Felaktigt format!")]
        public string EmailAddress { get; set; }

        //REGEX EFTER W3 standarden för accepterade emailadresser. http://www.w3.org/TR/html5/forms.html#valid-e-mail-address

    }
}