using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Äventyrliga_Kontakter.Model.DAL
{
    public class Service
    {
        private ContactDAL _ContactDAL;

        private ContactDAL ContactDAL
        {
            get { return _ContactDAL ?? (_ContactDAL = new ContactDAL()); }
        }

        #region DeleteContact
        
        public void DeleteContact(int contactID) {

            ContactDAL.DeleteContacts(contactID);
        }
        #endregion

        #region GetContact

        public Contact GetContact(int contactID) {

            return ContactDAL.GetContactByID(contactID);
        
        }

        #endregion

        #region GetContacts
        public IEnumerable<Contact> GetContacts() {            

            return ContactDAL.GetContacts();

        }
        #endregion

        #region SaveContact

        public void SaveContact(Contact contact) {

             ICollection<ValidationResult> ValidationResults;

             if (!contact.Validate(out ValidationResults)) {

                 var ex = new ValidationException("Objektet klarade inte valideringen");
                 ex.Data.Add("ValidationResults", ValidationResults);
                 throw ex;
             }
            

            if (contact.ContactID == 0)
            {

                ContactDAL.InsertContact(contact);
            }
            else {

                ContactDAL.UppdateContact(contact);
            }
        
        }

        #endregion


       

    }
}