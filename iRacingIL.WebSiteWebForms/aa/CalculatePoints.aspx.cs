using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms.aa
{
    public partial class CalculatePoints : BasePageAutenricatedOnly
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));

        }

        protected void _BTCalcPoints_Click(object sender, EventArgs e)
        {
            var s = db.seasons.Where(m => m.iscurrentseason == 1).Single();

            foreach (var r in s.races.Where(m => m.israced == 1))
            {
                Helpers.CalculateAllForRace(r, db);
            }
        }

    }

    
}