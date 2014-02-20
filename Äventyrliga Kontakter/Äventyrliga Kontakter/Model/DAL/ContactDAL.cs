using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Äventyrliga_Kontakter.Model.DAL
{
    public class ContactDAL: DALBase
    {
        #region DeleteContacts

        public void DeleteContacts(int contactID) {

            //TODO: IMPLEMENTERA ContactDAL - DeleteContacts()

            throw new NotImplementedException();

        }

        #endregion

        #region GetContacts()

        public IEnumerable<Contact> GetContacts()
        {

            using (var conn = CreateConnection())
            {
                try {

                    var contacts = new List<Contact>(100);

                    //TODO: Skapa ett SQL Command, öppna connection, kolla index på kolummerna, sätt egenskaperna i Contact-obj. med readern

                    contacts.TrimExcess();
                    
                    return contacts;


                
                }
                catch {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            
            }

            //TODO: IMPLEMENTERA ContactDAL - GetContacts()

            throw new NotImplementedException();
        }

        #endregion

        #region GetContactsByID

        public Contact GetContactByID(int contactID) {

            //TODO: Implementera ContactDAL - GetContactByID
            
            throw new NotImplementedException();


        }

        #endregion

        #region GetContactsPageWise

        public IEnumerable<Contact> GetContactsPageWise(int maxiumRows, int startRowIndex, out int totalRowCount) {

            //TODO: Implementera ContactDAL - GetContactsPageWise

            throw new NotImplementedException();
        }

        #endregion

        #region InsertContact

        public void InsertContact(Contact contact) {

            //TODO: Implementera ContactDAL - InsertContact

            throw new NotImplementedException();
        }

        #endregion

        #region UppdateContact

        public void UppdateContact(Contact contact) {

            //TODO: Implementera ContactDAL - UppdateContact

            throw new NotImplementedException();

        }

        #endregion
    }
}