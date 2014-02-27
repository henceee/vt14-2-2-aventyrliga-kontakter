using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Äventyrliga_Kontakter.Model.DAL
{
    public class ContactDAL: DALBase
    {
        #region DeleteContacts

        public void DeleteContacts(int contactID)
        {


            using (var conn = CreateConnection())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspRemoveContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contactID;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch
                {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
                
            }
        }

        #endregion

        #region GetContacts()

        public IEnumerable<Contact> GetContacts()
        {

            using (var conn = CreateConnection())
            {
                try {

                    var contacts = new List<Contact>(100);

                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader()) {

                        var ContactIDIndex = reader.GetOrdinal("ContactID");
                        var FirstNameIndex = reader.GetOrdinal("FirstName");
                        var LastNameIndex = reader.GetOrdinal("LastName");
                        var EmailIndex = reader.GetOrdinal("EmailAddress");

                        while (reader.Read()) {

                            contacts.Add(new Contact { 
                            
                               ContactID = reader.GetInt32(ContactIDIndex),
                               FirstName = reader.GetString(FirstNameIndex),
                               LastName = reader.GetString(LastNameIndex),
                               EmailAddress = reader.GetString(EmailIndex)

                            });
                        }
                    
                    }
                    

                    contacts.TrimExcess();
                    
                    return contacts;


                
                }
                catch {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            
            }
                                  
        }

        #endregion

        #region GetContactsByID

        public Contact GetContactByID(int contactID) {

            using (var conn = CreateConnection())
            {
                try {

                    SqlCommand cmd = new SqlCommand("Person.uspGetContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@ContactID", contactID);

                    conn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader()) {

                        if (reader.Read()) {

                            int ContactIDIndex = reader.GetOrdinal("ContactID");
                            int FirstNameIndex = reader.GetOrdinal("FirstName");
                            int LastNameIndex = reader.GetOrdinal("LastName");
                            int EmailIndex = reader.GetOrdinal("EmailAddress");

                            return new Contact {

                                ContactID = reader.GetInt32(ContactIDIndex),
                                FirstName = reader.GetString(FirstNameIndex),
                                LastName = reader.GetString(LastNameIndex),
                                EmailAddress = reader.GetString(EmailIndex)
                            
                            
                            };                        
                        }                        
                    }

                    return null;
                
                }
                catch
                {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
                
            }

        }

        #endregion

        #region GetContactsPageWise

        public IEnumerable<Contact> GetContactsPageWise(int maxiumRows, int startRowIndex, out int totalRowCount) {
            
            var contacts = new List<Contact>(100);

            using (var conn = CreateConnection())
            {
                try
                {
                    
                    var cmd = new SqlCommand("Person.uspGetContacts", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    conn.Open();

                    using (var reader = cmd.ExecuteReader())
                    {

                        var ContactIDIndex = reader.GetOrdinal("ContactID");
                        var FirstNameIndex = reader.GetOrdinal("FirstName");
                        var LastNameIndex = reader.GetOrdinal("LastName");
                        var EmailIndex = reader.GetOrdinal("EmailAddress");

                        while (reader.Read())
                        {

                            contacts.Add(new Contact
                            {

                                ContactID = reader.GetInt32(ContactIDIndex),
                                FirstName = reader.GetString(FirstNameIndex),
                                LastName = reader.GetString(LastNameIndex),
                                EmailAddress = reader.GetString(EmailIndex)

                            });
                        }

                    }


                    contacts.TrimExcess();

                    totalRowCount = contacts.Count;

                    return contacts.Skip(startRowIndex).Take(maxiumRows);



                }
                catch
                {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }

            }



            //TODO: Implementera ContactDAL - GetContactsPageWise

            throw new NotImplementedException();
        }

        #endregion

        #region InsertContact

        public void InsertContact(Contact contact) {
            

            using (var conn = CreateConnection()) {

                try {

                    SqlCommand cmd = new SqlCommand("Person.uspAddContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;
                   
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int,4).Direction = ParameterDirection.Output;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    contact.ContactID = (int)cmd.Parameters["@ContactID"].Value;

                
                }
                catch {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }

            }


           
        }

        #endregion

        #region UppdateContact

        public void UppdateContact(Contact contact) {

            using (var conn = CreateConnection())
            {

                try
                {
                    SqlCommand cmd = new SqlCommand("Person.uspUpdateContact", conn);
                    cmd.CommandType = CommandType.StoredProcedure;                 


                    cmd.Parameters.Add("@FirstName", SqlDbType.VarChar, 50).Value = contact.FirstName;
                    cmd.Parameters.Add("@LastName", SqlDbType.VarChar, 50).Value = contact.LastName;
                    cmd.Parameters.Add("@EmailAddress", SqlDbType.VarChar, 50).Value = contact.EmailAddress;
                    cmd.Parameters.Add("@ContactID", SqlDbType.Int, 4).Value = contact.ContactID;

                    conn.Open();
                    cmd.ExecuteNonQuery();

                }
                catch
                {

                    throw new ApplicationException("An error occured while getting customers from the database.");
                }
            }
                        

        }

        #endregion
    }
}