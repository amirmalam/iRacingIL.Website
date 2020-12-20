using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class Steward : BasePageAutenricatedOnly
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            _DVForm.Style.Add("display", "block");
            base.Page_Load(sender, e);

            Page.Title = "Steward - iRacing Israel League";

            Page.Header.Controls.Add(
   new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));

            _LIMessage.Text = string.Empty;
            if (!IsPostBack)
            {
                BindDDLs();
                BindPunishDLLs();
                BindForm();

            }
        }
        private int GetSelectedIncidentStuartID()
        {
            if (_DDLNeedTo.SelectedIndex != 0)
                return int.Parse(_DDLNeedTo.SelectedValue);
            else if (_DDLDone.SelectedIndex != 0)
                return int.Parse(_DDLDone.SelectedValue);

            return 0;
        }
        private void BindDDLs()
        {
            race r = Helpers.GetLastRacedRace(db);
            var incidents = db.incident_stuarts.Where(m => m.incident.raceid == r.raceid && m.stuartid == UserID).ToList();
            if(incidents.Count == 0)
            {
                _LIMessage.Text = "No incidents assigned to you.";
            }

            foreach(var inc in incidents)
            {
                ListItem li = new ListItem($"ID: {inc.incidentid}; Lap: {inc.incident.lap}; Turn: {inc.incident.turn}",inc.idincident_stuartsid.ToString());
                if(string.IsNullOrEmpty(inc.desc))
                    _DDLNeedTo.Items.Add(li);
                else
                    _DDLDone.Items.Add(li);
            }
            _DDLDone.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            _DDLNeedTo.Items.Insert(0, new ListItem(string.Empty, string.Empty));
            if (_DDLNeedTo.Items.Count > 1)
                _DDLNeedTo.SelectedIndex = 1;
            else
                _DDLDone.SelectedIndex = 1;

        }
        private void BindForm()
        {
            int incidentStuartID = GetSelectedIncidentStuartID();
            race race = Helpers.GetLastRacedRace(db);
            
            if(incidentStuartID > 0 && race.israceclosed == 0)
            {
                incident_stuarts inst = db.incident_stuarts.Where(m => m.idincident_stuartsid == incidentStuartID).Single();

                _TBConclutions.Text = inst.desc;
                _LADesc.Text = inst.incident.desc;
                _LALap.Text = inst.incident.lap.ToString();
                _LATurn.Text = inst.incident.turn;
                BindIncidentDriversDLL(_DDLDriver1, inst);
                BindIncidentDriversDLL(_DDLDriver2, inst);
                BindIncidentDriversDLL(_DDLDriver3, inst);
                for(int i=0;i<inst.incident_stuart_result.Count;i++)
                {
                    if (i == 0)
                    {
                        _DDLDriver1.SelectedValue = inst.incident_stuart_result.ToList()[i].driverid.ToString();
                        _DDLPunish1.SelectedValue = inst.incident_stuart_result.ToList()[i].cat.ToString();
                    }
                    else if (i == 1)
                    {
                        _DDLDriver2.SelectedValue = inst.incident_stuart_result.ToList()[i].driverid.ToString();
                        _DDLPunish2.SelectedValue = inst.incident_stuart_result.ToList()[i].cat.ToString();
                    }
                    else if (i == 2)
                    {
                        _DDLDriver3.SelectedValue = inst.incident_stuart_result.ToList()[i].driverid.ToString();
                        _DDLPunish3.SelectedValue = inst.incident_stuart_result.ToList()[i].cat.ToString();
                    }
                }

                _REPResponses.DataSource = inst.incident.incident_drivers;
                _REPResponses.DataBind();
                
            }
            else
            {
                _DVForm.Style.Add("display", "none");
            }
        }
        private void BindIncidentDriversDLL(DropDownList ddl,incident_stuarts inst)
        {
            ddl.Items.Clear();
            ddl.Items.Add(new ListItem(string.Empty, string.Empty));
            foreach(var d in inst.incident.incident_drivers.OrderBy(m=>m.driver.name))
            {
                ddl.Items.Add(new ListItem(d.driver.name, d.driverid.ToString()));
            }
        }

        private void BindPunishDLLs()
        {
            _DDLPunish1.Items.Clear();
            _DDLPunish2.Items.Clear();
            _DDLPunish3.Items.Clear();

           ListItem li0 = new ListItem("", "");
            ListItem li1 = new ListItem("CAT1", "1");
            ListItem li2 = new ListItem("CAT2", "2");
            ListItem li3 = new ListItem("CAT3", "3");
            ListItem li4 = new ListItem("CAT4", "4");
            ListItem li5 = new ListItem("CAT5", "5");

            ListItem li0a = new ListItem("", "");
            ListItem li1a = new ListItem("CAT1", "1");
            ListItem li2a = new ListItem("CAT2", "2");
            ListItem li3a = new ListItem("CAT3", "3");
            ListItem li4a = new ListItem("CAT4", "4");
            ListItem li5a = new ListItem("CAT5", "5");

            ListItem li0b = new ListItem("", "");
            ListItem li1b = new ListItem("CAT1", "1");
            ListItem li2b = new ListItem("CAT2", "2");
            ListItem li3b = new ListItem("CAT3", "3");
            ListItem li4b = new ListItem("CAT4", "4");
            ListItem li5b = new ListItem("CAT5", "5");

            _DDLPunish1.Items.AddRange(new ListItem[] { li0, li1, li2, li3, li4, li5 });
            _DDLPunish2.Items.AddRange(new ListItem[] { li0a, li1a, li2a, li3a, li4a, li5a });
            _DDLPunish3.Items.AddRange(new ListItem[] { li0b, li1b, li2b, li3b, li4b, li5b });
        }

        protected void _BTSubmit_Click(object sender, EventArgs e)
        {
            
            int incidentStuartID = GetSelectedIncidentStuartID();

            if (incidentStuartID > 0)
            {
                incident_stuarts inst = db.incident_stuarts.Where(m => m.idincident_stuartsid == incidentStuartID).Single();

                foreach (var r in inst.incident_stuart_result.ToList())
                    db.incident_stuart_result.Remove(r);

                db.SaveChanges();

                inst.desc = _TBConclutions.Text.MakeMySQLSafe();

                if(_DDLDriver1.SelectedValue != string.Empty && _DDLPunish1.SelectedValue != string.Empty)
                {
                    incident_stuart_result s = new incident_stuart_result();
                    s.driverid =  int.Parse(_DDLDriver1.SelectedValue);
                    s.cat = int.Parse(_DDLPunish1.SelectedValue);
                    s.incident_stuartid = incidentStuartID;
                    db.incident_stuart_result.Add(s);
                }
                if (_DDLDriver2.SelectedValue != string.Empty && _DDLPunish2.SelectedValue != string.Empty)
                {
                    incident_stuart_result s = new incident_stuart_result();
                    s.driverid = int.Parse(_DDLDriver2.SelectedValue);
                    s.cat = int.Parse(_DDLPunish2.SelectedValue);
                    s.incident_stuartid = incidentStuartID;
                    db.incident_stuart_result.Add(s);
                }
                if (_DDLDriver3.SelectedValue != string.Empty && _DDLPunish3.SelectedValue != string.Empty)
                {
                    incident_stuart_result s = new incident_stuart_result();
                    s.driverid = int.Parse(_DDLDriver3.SelectedValue);
                    s.cat = int.Parse(_DDLPunish3.SelectedValue);
                    s.incident_stuartid = incidentStuartID;
                    db.incident_stuart_result.Add(s);
                }

                db.SaveChanges();

            }

            _LIMessage.Text = "Decision saved!";
            //Response.Redirect(Request.RawUrl);
                
        }

        protected void _DDLNeedTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            if (ddl.ID == "_DDLNeedTo")
                _DDLDone.SelectedValue = string.Empty;
            else
                _DDLNeedTo.SelectedValue = string.Empty;

            BindForm();
        }
    }
}
