using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class Contact : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(
new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));

            Page.Title = "Contact Us - iRacing Israel League";
        }

        protected void _BTSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                string[] to = System.Configuration.ConfigurationManager.AppSettings["contactus:to"].Split(';');
                string subject = "iil contact: " + _DDLSubject.SelectedItem.Text;
                string body = $"Email: {_TBEmail.Text}\n\nBody: {_TBEmail.Text}";

                Helpers.SendEmail(to, subject, body);

                _LIMessage.Text = "Thank you for contacting us!";
            }
            catch
            {
                _LIMessage.Text = "Error! Message did not send.";
            }
        }
    }
}