using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Äventyrliga_Kontakter.Model;
using Äventyrliga_Kontakter.Model.DAL;

namespace Äventyrliga_Kontakter
{
    public partial class Default : System.Web.UI.Page
    {
        private Service _Service;

        private Service Service
        {
            get { return _Service ?? (_Service = new Service()); }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

        }

       
        public IEnumerable<Contact> ListView1_GetData()
        {
            return Service.GetContacts();
        }
    }
}