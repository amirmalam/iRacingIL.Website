using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms.aa
{
    public partial class AssignSteward : BasePageAutenricatedOnly
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));


            _LAMessage.Text = string.Empty;



            if(!IsPostBack)
            {
                GenerateStuarts();
                
            }
            DisableIfAlreadyAssigned();



        }

        private void DisableIfAlreadyAssigned()
        {
            var race = Helpers.GetLastRacedRace(db);

            _LIRaceName.Text = race.racenumber + ": " + race.track.name;

            var currentStuarts = db.incident_stuarts.Where(m => m.incident.raceid == race.raceid).ToList();
            if (currentStuarts.Count() > 0)
            {
                _DDLStuart1.Enabled = false;
                _DDLStuart2.Enabled = false;
                _DDLStuart3.Enabled = false;
                _DDLStuart4.Enabled = false;

                for (int i = 0; i < currentStuarts.Count; i++)
                {
                    if (i == 0)
                        _DDLStuart1.SelectedValue = currentStuarts[i].stuartid.ToString();
                    else if (i == 1)
                        _DDLStuart2.SelectedValue = currentStuarts[i].stuartid.ToString();
                    else if (i == 2)
                        _DDLStuart3.SelectedValue = currentStuarts[i].stuartid.ToString();
                    else if (i == 3)
                        _DDLStuart4.SelectedValue = currentStuarts[i].stuartid.ToString();
                }

                _BTSaveStuarts.Enabled = false;
            }
        }

        protected void GenerateStuarts()
        {
            var race = Helpers.GetLastRacedRace(db);

            List<driver> noDrivers = new List<driver>();
            foreach (var x in db.incidents.Where(m => m.raceid == race.raceid).ToList())
            {
                foreach (var y in x.incident_drivers)
                {
                    noDrivers.Add(y.driver);
                }
            }

            List<raceresult> yesDrivers = new List<raceresult>();
            foreach (raceresult d in db.raceresults.Where(m => m.raceid == race.raceid).ToList())
            {
                var count = noDrivers.Where(m => m.driverid == d.driverid).Count();
                if (count == 0)
                {
                    yesDrivers.Add(d);
                }
            }

            yesDrivers = yesDrivers.OrderBy(m => m.driver.name).ToList();



            //yesDrivers.Shuffle();

            foreach (var d in yesDrivers)
            {
                _DDLStuart1.Items.Add(new ListItem(d.driver.name, d.driverid.ToString()));
                _DDLStuart2.Items.Add(new ListItem(d.driver.name, d.driverid.ToString()));
                _DDLStuart3.Items.Add(new ListItem(d.driver.name, d.driverid.ToString()));
                _DDLStuart4.Items.Add(new ListItem(d.driver.name, d.driverid.ToString()));
            }

            Random rnd = new Random();
            int start = rnd.Next(0, 9);

            _DDLStuart1.SelectedIndex = start;
            start++;
            start = start == 10 ? 0 : start;

            _DDLStuart2.SelectedIndex = start;
            start++;
            start = start == 10 ? 0 : start;

            _DDLStuart3.SelectedIndex = start;
            start++;
            start = start == 10 ? 0 : start;

            _DDLStuart4.SelectedIndex = start;
            start++;
            start = start == 10 ? 0 : start;



        }

        protected void _BTSaveStuarts_Click(object sender, EventArgs e)
        {
            int stuart1 = int.Parse(_DDLStuart1.SelectedValue);
            int stuart2 = int.Parse(_DDLStuart2.SelectedValue);
            int stuart3 = int.Parse(_DDLStuart3.SelectedValue);
            int stuart4 = int.Parse(_DDLStuart4.SelectedValue);

            race r = Helpers.GetLastRacedRace(db);
            foreach(incident inc in db.incidents.Where(m=>m.raceid == r.raceid).ToList())
            {
                incident_stuarts s1 = new incident_stuarts();
                s1.incidentid = inc.incidentid;
                s1.stuartid = stuart1;
                s1.desc = string.Empty;

                incident_stuarts s2 = new incident_stuarts();
                s2.incidentid = inc.incidentid;
                s2.stuartid = stuart2;
                s2.desc = string.Empty;

                incident_stuarts s3 = new incident_stuarts();
                s3.incidentid = inc.incidentid;
                s3.stuartid = stuart3;
                s3.desc = string.Empty;

                incident_stuarts s4 = new incident_stuarts();
                s4.incidentid = inc.incidentid;
                s4.stuartid = stuart4;
                s4.desc = string.Empty;

                db.incident_stuarts.Add(s1);
                db.incident_stuarts.Add(s2);
                db.incident_stuarts.Add(s3);
                db.incident_stuarts.Add(s4);
            }

            db.SaveChanges();

            _LAMessage.Text = "All stewards saved successfull!";
        }
    }
}