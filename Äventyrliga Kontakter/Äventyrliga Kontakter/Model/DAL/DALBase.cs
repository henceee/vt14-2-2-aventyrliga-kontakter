using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Äventyrliga_Kontakter.Model.DAL
{
    public abstract class DALBase
    {
        

        private static string _connectionstring;

        protected static DALBase() {

            _connectionstring = WebConfigurationManager.ConnectionStrings["1dv406_AdventureWorksAssignmentConnectionString"].ConnectionString;
          
        }

        #region CreateConnection

        protected SqlConnection CreateConnection() {

            return new SqlConnection(_connectionstring);

        
        }


        #endregion

    }
}