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
            if (Session["success"] as bool? == true)
            {

                Sucess.Visible = true;
                Session.Remove("success");
            }
           

            
        }

        #region GetData
                                                       //
        public IEnumerable<Contact> ListView1_GetData(int maximumRows, int startRowIndex, out int totalRowCount)
        {
                                        //
            return Service.GetContacts(maximumRows, startRowIndex, out totalRowCount);
                        
        }
        #endregion

        #region InsertItem
        public void ListView1_InsertItem(Contact contact)
        {
           
                if (ModelState.IsValid) {

                    try
                    {
                        Service.SaveContact(contact);
                        Session["success"] = true;
                        Response.Redirect("~/");
                    }
                    catch (Exception)
                    {
                        ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle läggas till.");
                    }
                }
        }

        #endregion

        #region UpdateItem
        // The id parameter name should match the DataKeyNames value set on the control
        public void ListView1_UpdateItem(int contactID)
        {

            try {

                var contact = Service.GetContact(contactID);
                if (contact == null) {

                    ModelState.AddModelError(String.Empty,
                        String.Format("Kontakten med kontaktnummer {0} hittades inte.", contactID));

                    return;
                }

                if (TryUpdateModel(contact)) {

                    Service.SaveContact(contact);

                }
            
            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle uppdateras.");
            }

           
        }

         #endregion

        #region DeleteItem
        // The id parameter name should match the DataKeyNames value set on the control
        public void ListView1_DeleteItem(int contactID)
        {
            try {

                Service.DeleteContact(contactID);

            }
            catch (Exception)
            {
                ModelState.AddModelError(String.Empty, "Ett oväntat fel inträffade då kunduppgiften skulle tas bort.");
            }
        }
         #endregion



 



       
      

       
    }
}