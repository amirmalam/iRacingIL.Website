using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class LoginCallback : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            string email = ((ClaimsIdentity)HttpContext.Current.User.Identity).Claims.Where(m => m.Type == "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress").Single().Value;

            Session["email"] = email;

            int userid = 0;
            try
            {
                userid = new iracingilEntities().drivers.Where(m => m.email == email).Single().driverid;
            }
            catch
            {

            }
            Session["userid"] = userid;

            string[] adminusers = System.Configuration.ConfigurationManager.AppSettings["adminusers"].Split(';');

            if (adminusers.Contains(email))
                Session["isadmin"] = true;

            Response.Redirect("/");
        }
    }
}