using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class IncidentResponse : BasePageAutenricatedOnly
    {
        //protected incident_drivers mIncident_Driver;
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(
    new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));

            Page.Title = "Incident Response - iRacing Israel League";

            _LIMessage.Text = string.Empty;

            if(!IsPostBack)
            {
                BindIncidents();
            }
        }

        private void BindForm()
        {
            var incident_Driver = db.incident_drivers.Where(m => m.idincident_driversid.ToString() == _DDLIncidents.SelectedValue).Single();
            _LAIncidentName.Text = _DDLIncidents.SelectedItem.Text;
            _LIDesc.Text = incident_Driver.incident.desc;
            _TBResponse.Text = incident_Driver.response;

            var alldrivers = db.incident_drivers.Where(m => m.incidentid == incident_Driver.incidentid);
            string drivers = string.Empty;
            foreach (var driver in alldrivers)
                drivers += driver.driver.name + ",";
            if (drivers.Length > 5)
                drivers = drivers.Substring(0, drivers.Length - 1);
            _LIDrivers.Text = drivers;
        }

        private void BindIncidents()
        {
            var race = Helpers.GetLastRacedRace(db);

            _LIRaceName.Text = race.track.name;
            var incidents_drivers = db.incident_drivers.Where(m => m.driverid == UserID && m.incident.race.raceid == race.raceid).ToList();
            if (incidents_drivers.Count == 0)
            {
                _LIMessage.Text = "You have not incidents to response too. Good job!";
                _BTSubmit.Enabled = false;
                divForm.Visible = false;
                _DDLIncidents.Visible = false;
            }
            else
            {

                foreach (var incidents_driver in incidents_drivers)
                {
                    ListItem li = new ListItem($"Lap: {incidents_driver.incident.lap};Turn: {incidents_driver.incident.turn}", incidents_driver.idincident_driversid.ToString());
                    _DDLIncidents.Items.Add(li);
                }

                _DDLIncidents.Items[0].Selected = true;
                BindForm();
            }
        }

        protected void _DDLIncidents_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindForm();   
        }

        protected void _BTSubmit_Click(object sender, EventArgs e)
        {
            incident_drivers id = db.incident_drivers.Where(m=>m.idincident_driversid.ToString() == _DDLIncidents.SelectedValue).Single();

            id.response = _TBResponse.Text.MakeMySQLSafe();

            db.SaveChanges();

            _LIMessage.Text = "Response saves successfully!";

            
            
            
        }
    }
}