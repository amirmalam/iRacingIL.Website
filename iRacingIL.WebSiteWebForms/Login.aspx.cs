using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HttpContext.Current.GetOwinContext().Authentication.Challenge(new AuthenticationProperties
            {
                
                RedirectUri = System.Configuration.ConfigurationManager.AppSettings["auth0:RedirectUri"]
            },
            "Auth0") ;
            //Response.Redirect("/login");
        }
    }
}