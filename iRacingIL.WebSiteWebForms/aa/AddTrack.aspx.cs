using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms.aa
{
    public partial class AddTrack : BasePageAutenricatedOnly
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(
new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));


            _BTSubmit.Click += _BTSubmit_Click;
        }

        private void _BTSubmit_Click(object sender, EventArgs e)
        {
            track s = new track();
            s.name = _TBName.Text;
            s.config = _TBConfig.Text;

            db.tracks.Add(s);
            db.SaveChanges();
        }
    }
}