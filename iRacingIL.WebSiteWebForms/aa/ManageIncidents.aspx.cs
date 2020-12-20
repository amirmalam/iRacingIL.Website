using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms.aa
{
    public partial class ManageIncidents : BasePageAutenricatedOnly
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));


            PAlert.Visible = false;

            if (!IsPostBack)
            {
                BindIncidents();
                //BindDriversDLL();
                
            }
        }
        private void BindForm()
        {
            incident inc = db.incidents.Where(m => m.incidentid.ToString() == _DDLIncidents.SelectedValue).Single();
            _LIIncidentName.Text = $"{inc.driver.name} - L: {inc.lap} - T: {inc.turn}";
            _LIIncidentID.Text = inc.incidentid.ToString();
            _LIReporter.Text = inc.driver.name;
            _LIDescription.Text = inc.desc;


            var drivers = inc.incident_drivers.Select(m => m.driver).ToList();
            _LIDriversInvlove.Text = string.Empty;
            for (int i=0;i<drivers.Count;i++)
            {
                _LIDriversInvlove.Text += drivers[i].name + ",";
            }
            _LIDriversInvlove.Text.TrimEnd(',');

            _REPResponses.DataSource = inc.incident_drivers.ToList();
            _REPResponses.DataBind();

            _REPStuarts.DataSource = inc.incident_stuarts.ToList();
            _REPStuarts.ItemDataBound += _REPStuarts_ItemDataBound;
            _REPStuarts.DataBind();

            BindDriversDLL();
            

        }

        private void _REPStuarts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            int isid = int.Parse((e.Item.FindControl("HFIncidentStuartID") as HiddenField).Value);
            var st = db.incident_stuarts.Where(m => m.idincident_stuartsid == isid).Single();

            if (st.incident_stuart_result.Count() == 0)
            {
                (e.Item.FindControl("PNoDecition") as Control).Visible = true;
            }
            else
            {
                Repeater rep = e.Item.FindControl("REPDecisions") as Repeater;
                rep.DataSource = st.incident_stuart_result;
                rep.DataBind();
            }

        }

        private void BindIncidents()
        {
            var race = Helpers.GetLastRacedRace(db);
            var incidents = db.incidents.Where(m => m.raceid == race.raceid).OrderBy(m => m.lap).ToList();
            foreach(var inc in incidents)
            {
                ListItem li = new ListItem($"{inc.driver.name}  L: {inc.lap} T: {inc.turn}", inc.incidentid.ToString());
                _DDLIncidents.Items.Add(li);
            }
            if(incidents.Count > 0)
                BindForm();
        }

        
        private void BindDriversDLL()
        {
            int raceid = Helpers.GetLastRacedRace(db).raceid;
            var inc = db.incidents.Where(m => m.incidentid.ToString() == _DDLIncidents.SelectedValue).Single();

            _DDLDriversFinal1.DataSource = inc.incident_drivers.Select(m=>m.driver);
            _DDLDriversFinal1.DataTextField = "name";
            _DDLDriversFinal1.DataValueField = "driverid";
            _DDLDriversFinal1.DataBind();
            

            _DDLDriversFinal2.DataSource = inc.incident_drivers.Select(m => m.driver);
            _DDLDriversFinal2.DataTextField = "name";
            _DDLDriversFinal2.DataValueField = "driverid";
            _DDLDriversFinal2.DataBind();

            _DDLDriversFinal3.DataSource = inc.incident_drivers.Select(m => m.driver);
            _DDLDriversFinal3.DataTextField = "name";
            _DDLDriversFinal3.DataValueField = "driverid";
            _DDLDriversFinal3.DataBind();

            _DDLDriversFinal1.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            _DDLDriversFinal2.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            _DDLDriversFinal3.Items.Insert(0, new ListItem(string.Empty, string.Empty));

            _DDLCatFinal1.Items.Clear();
            _DDLCatFinal2.Items.Clear();
            _DDLCatFinal3.Items.Clear();

            _DDLCatFinal1.Items.Add(new ListItem(string.Empty, string.Empty));
            _DDLCatFinal1.Items.Add(new ListItem("CAT1", "1"));
            _DDLCatFinal1.Items.Add(new ListItem("CAT2", "2"));
            _DDLCatFinal1.Items.Add(new ListItem("CAT3", "3"));
            _DDLCatFinal1.Items.Add(new ListItem("CAT4", "4"));
            _DDLCatFinal1.Items.Add(new ListItem("CAT5", "5"));

            _DDLCatFinal2.Items.Add(new ListItem(string.Empty, string.Empty));
            _DDLCatFinal2.Items.Add(new ListItem("CAT1", "1"));
            _DDLCatFinal2.Items.Add(new ListItem("CAT2", "2"));
            _DDLCatFinal2.Items.Add(new ListItem("CAT3", "3"));
            _DDLCatFinal2.Items.Add(new ListItem("CAT4", "4"));
            _DDLCatFinal2.Items.Add(new ListItem("CAT5", "5"));

            _DDLCatFinal3.Items.Add(new ListItem(string.Empty, string.Empty));
            _DDLCatFinal3.Items.Add(new ListItem("CAT1", "1"));
            _DDLCatFinal3.Items.Add(new ListItem("CAT2", "2"));
            _DDLCatFinal3.Items.Add(new ListItem("CAT3", "3"));
            _DDLCatFinal3.Items.Add(new ListItem("CAT4", "4"));
            _DDLCatFinal3.Items.Add(new ListItem("CAT5", "5"));

            var results = db.incident_final_results.Where(m => m.incidentid == inc.incidentid).ToList();
            for (int i=0;i<results.Count;i++)
            {
                if(i==0)
                {
                    _DDLDriversFinal1.SelectedValue = results[i].driverid.ToString();
                    _DDLCatFinal1.SelectedValue = results[i].cat.ToString();
                }
                else if (i == 1)
                {
                    _DDLDriversFinal2.SelectedValue = results[i].driverid.ToString();
                    _DDLCatFinal2.SelectedValue = results[i].cat.ToString();
                }
                else if (i == 2)
                {
                    _DDLDriversFinal3.SelectedValue = results[i].driverid.ToString();
                    _DDLCatFinal3.SelectedValue = results[i].cat.ToString();
                }

            }

        }
        
        protected void _DDLIncidents_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindForm();
        }

        protected void _TBDelete_Click(object sender, EventArgs e)
        {
            incident inc = db.incidents.Where(m => m.incidentid.ToString() == _DDLIncidents.SelectedValue).Single();
            db.incidents.Remove(inc);
            db.SaveChanges();
            Response.Redirect(Request.RawUrl);
        }

        protected void _BTSubmitFinal_Click(object sender, EventArgs e)
        {
            var results = db.incident_final_results.Where(m => m.incidentid.ToString() == _DDLIncidents.SelectedValue).ToList();
            foreach(var item in results)
            {
                db.incident_final_results.Remove(item);
            }

            db.SaveChanges();
            int incid = int.Parse(_DDLIncidents.SelectedValue);
            if(!string.IsNullOrEmpty(_DDLDriversFinal1.SelectedValue) && !string.IsNullOrEmpty(_DDLCatFinal1.SelectedValue))
            {
                incident_final_results ifr = new incident_final_results();
                ifr.driverid = int.Parse(_DDLDriversFinal1.SelectedValue);
                ifr.cat = int.Parse(_DDLCatFinal1.SelectedValue);
                ifr.incidentid = incid;
                db.incident_final_results.Add(ifr);
            }
            if (!string.IsNullOrEmpty(_DDLDriversFinal2.SelectedValue) && !string.IsNullOrEmpty(_DDLCatFinal2.SelectedValue))
            {
                incident_final_results ifr = new incident_final_results();
                ifr.driverid = int.Parse(_DDLDriversFinal2.SelectedValue);
                ifr.cat = int.Parse(_DDLCatFinal2.SelectedValue);
                ifr.incidentid = incid;
                db.incident_final_results.Add(ifr);
            }
            if (!string.IsNullOrEmpty(_DDLDriversFinal3.SelectedValue) && !string.IsNullOrEmpty(_DDLCatFinal3.SelectedValue))
            {
                incident_final_results ifr = new incident_final_results();
                ifr.driverid = int.Parse(_DDLDriversFinal3.SelectedValue);
                ifr.cat = int.Parse(_DDLCatFinal3.SelectedValue);
                ifr.incidentid = incid;
                db.incident_final_results.Add(ifr);
            }

            db.SaveChanges();
            PAlert.Visible = true;
        }

        protected void _BTCloseAllIncidents_Click(object sender, EventArgs e)
        {
            race race = Helpers.GetLastRacedRace(db);
            int maxLap = db.raceresults.Where(m => m.raceid == race.raceid).OrderByDescending(m => m.lapscomlited).First().lapscomlited;

            Dictionary<int, int> driversScores = new Dictionary<int, int>();

            foreach(var inc in race.incidents)
            {
                foreach(var result in inc.incident_final_results)
                {
                    if (!driversScores.ContainsKey(result.driverid))
                        driversScores.Add(result.driverid, 0);
                    driversScores[result.driverid] += GetPointsByCat(result.cat);
                }
            }


            foreach(int driverid in driversScores.Keys)
            {
                db.raceresults.Where(m => m.raceid == race.raceid && m.driverid == driverid).Single().saftypointsaddition = driversScores[driverid];
                db.drivers.Where(m => m.driverid == driverid).Single().saftypoints += driversScores[driverid];
            }

            db.SaveChanges();

            foreach (raceresult result in db.raceresults.Where(m => m.raceid == race.raceid && m.saftypointsaddition == 0 && m.lapscomlited >= (maxLap * 0.75)).ToList())
            {
                
                var driver = db.drivers.Where(m => m.driverid == result.driverid).Single();
                var pointsaddition = 1;
                if (driver.saftypoints < 50)
                    pointsaddition = 6;
                result.saftypointsaddition = pointsaddition;
                driver.saftypoints += pointsaddition;
            }

            race.israceclosed = 1;
            db.SaveChanges();
            Response.Redirect("/aa");

        }

        private int GetPointsByCat(int cat)
        {
            switch(cat)
            {
                case 0:return 0;
                case 1: return -4;
                case 2: return -7;
                case 3: return -11;
                case 4: return -16;
                case 5: return -30;
            }
            return 0;
        }
    }
}