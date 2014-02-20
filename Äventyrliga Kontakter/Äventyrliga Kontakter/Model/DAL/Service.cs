using System;
using System.Collections.Generic;
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


        public IEnumerable<Contact> GetContacts() {            

            return ContactDAL.GetContacts();
        
        }
    }
}