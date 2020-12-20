using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class SiteMaster : MasterPage
    {
        protected race mRace;

        protected string Email
        {
            get
            {
                return ((BasePage)Page).Email;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            iracingilEntities db = new iracingilEntities();

            mRace = Helpers.GetLastRacedRace(db);
            bool lastRaceHasStuarts = false;
            if (mRace != null)
            {
                foreach (var incident in mRace.incidents)
                {
                    foreach (var stuart in incident.incident_stuarts)
                    {
                        lastRaceHasStuarts = true;
                        break;
                    }
                    if (lastRaceHasStuarts)
                        break;
                }
            }
            if (((BasePage)Page).UserID > 0)
            {
                divLogout.Visible = true;
                divLogin.Visible = false;
                //_LIReportIncident.Visible = true; //lastRaceHasStuarts ? false: true;
                navIncidentResponse.Visible = lastRaceHasStuarts || mRace == null ? false : true;
                navStuart.Visible = lastRaceHasStuarts && mRace.israceclosed == 0 ? true : false;

            }
            else
            {
                divLogout.Visible = false;
                divLogin.Visible = true;
                //_LIReportIncident.Visible = false;
                navIncidentResponse.Visible = false;
                navStuart.Visible = false;
            }
 
                navAdmin.Visible = ((BasePage)Page).IsAdmin ? true : false;

        }
    }
}