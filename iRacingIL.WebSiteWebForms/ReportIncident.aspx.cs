using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class ReportIncident : BasePage
    {
        
        private race mRace = null;
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(
   new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));

            Page.Title = "Incidents Report - iRacing Israel League";
            var races = db.races.Where(m => m.israced == 1 && m.season.iscurrentseason == 1).OrderByDescending(m => m.racenumber);

            bool hasStuarts = false;
            if (races.Count() > 0)
            {
                mRace = races.Take(1).Single();

                foreach (var inc in mRace.incidents.Where(m => m.raceid == mRace.raceid).ToList())
                {
                    foreach (var stuart in inc.incident_stuarts.Where(m => m.incidentid == inc.incidentid))
                    {
                        hasStuarts = true;
                    }
                    if (hasStuarts) break;
                }
            }
            if (UserID > 0 && hasStuarts)
            {
                _LAReportClosed.Text = "Incident report is CLOSED and will be open for 24 hours after next race.";
                divForm.Style.Add("display", "none");
            }
            else
            {
                if (UserID == 0)
                    divForm.Style.Add("display", "none");

                if (!IsPostBack)
                    BindDrivers();
            }
            if (mRace != null)
            {
                _LIRace.Text = $"{mRace.season.name} - Race {mRace.racenumber} - {mRace.track.name} - {mRace.track.config}";
                _LIRaceName.Text = mRace.racenumber + ": " + mRace.track.name;

                _REPReports.DataSource = db.incidents.Where(m => m.raceid == mRace.raceid).ToList();
                _REPReports.ItemDataBound += _REPReports_ItemDataBound;
                _REPReports.DataBind();
            }
            else
                divForm.Style.Add("display", "none");

        }

        private void _REPReports_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int incidentid = ((incident)e.Item.DataItem).incidentid;
            var drivers = db.incident_drivers.Where(m => m.incidentid == incidentid).ToList();

            for(int i=0;i < drivers.Count;i++)
            {
                ((Literal)e.Item.FindControl("LIDriver" + (i + 1))).Text = drivers[i].driver.name; 
            }
        }

        protected void _BTSubmit_Click(object sender, EventArgs e)
        {
            incident incident = new incident();
            incident.desc = _DDLDesc.SelectedItem.Text;
            incident.reporterid = UserID;
            incident.lap = int.Parse(_TBLap.Text);
            incident.raceid = mRace.raceid;
            incident.turn = _TBTurn.Text.MakeMySQLSafe();

            db.incidents.Add(incident);
            db.SaveChanges();


            if (!string.IsNullOrEmpty(_DDLDriver1.SelectedValue))
            {
                incident_drivers d = new incident_drivers();
                d.driverid = int.Parse(_DDLDriver1.SelectedValue);
                d.incidentid = incident.incidentid;
                d.response = string.Empty;

                db.incident_drivers.Add(d);
                db.SaveChanges();
            }
            if (!string.IsNullOrEmpty(_DDLDriver2.SelectedValue))
            {
                incident_drivers d = new incident_drivers();
                d.driverid = int.Parse(_DDLDriver2.SelectedValue);
                d.incidentid = incident.incidentid;
                d.response = string.Empty;

                db.incident_drivers.Add(d);
                db.SaveChanges();
            }
            if (!string.IsNullOrEmpty(_DDLDriver3.SelectedValue))
            {
                incident_drivers d = new incident_drivers();
                d.driverid = int.Parse(_DDLDriver3.SelectedValue);
                d.incidentid = incident.incidentid;
                d.response = string.Empty;

                db.incident_drivers.Add(d);
                db.SaveChanges();
            }

            

            Response.Redirect(Request.RawUrl);


        }

        private void BindDrivers()
        {
            if (mRace != null)
            {
                _DDLDriver1.Items.Add(new ListItem("", ""));
                _DDLDriver2.Items.Add(new ListItem("", ""));
                _DDLDriver3.Items.Add(new ListItem("", ""));

                var drivers = db.raceresults.Where(m => m.raceid == mRace.raceid).Select(m => m.driver).ToList();

                foreach (var d in drivers.OrderBy(m=>m.name))
                {
                    _DDLDriver1.Items.Add(new ListItem(d.name, d.driverid.ToString()));
                    _DDLDriver2.Items.Add(new ListItem(d.name, d.driverid.ToString()));
                    _DDLDriver3.Items.Add(new ListItem(d.name, d.driverid.ToString()));
                }
            }
        }

       
    }
}