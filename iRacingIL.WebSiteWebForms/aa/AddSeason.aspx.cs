using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{

    public partial class AddSeason : BasePageAutenricatedOnly
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
            season s = new season();
            s.name = _TBName.Text;
            s.car = _TBCar.Text;
            s.iscurrentseason = _CBIsCurrent.Checked ? (byte)1:(byte)0;
            s.number = int.Parse(_TBNumber.Text);

            db.seasons.Add(s);
            db.SaveChanges();
        }
    }
}