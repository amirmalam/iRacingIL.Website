using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iRacingIL.WebSiteWebForms
{
    public class BasePageAutenricatedOnly:BasePage
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

            if (UserID == 0)
                Response.Redirect("/");
        }
    }
}