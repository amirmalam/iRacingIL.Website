using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class RaceResults : BasePage
    {
        protected race mRace;
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);
            mRace = Helpers.GetLastRacedRace(db);

            Page.Title = mRace.racenumber +": " + mRace.track.name + " - iRacing Israel League";

            int seasonid = string.IsNullOrEmpty(Request.QueryString["m"]) ? mRace.seasonid : int.Parse(Request.QueryString["m"]);
            int raceid = string.IsNullOrEmpty(Request.QueryString["r"]) ? mRace.raceid : int.Parse(Request.QueryString["r"]);
            if (seasonid != mRace.seasonid && string.IsNullOrEmpty(Request.QueryString["r"]))
                raceid = db.races.Where(m => m.seasonid == seasonid).OrderBy(m => m.racenumber).First().raceid;

            mRace = db.races.Where(m => m.raceid == raceid).Single();

            Dictionary<int, season> seasons = new Dictionary<int, season>();
            foreach(var race in db.races.Where(m=>m.israced == 1).ToList())
            {
                if (!seasons.ContainsKey(race.seasonid))
                    seasons.Add(race.seasonid, race.season);
            }
            _REPSeasons.DataSource = seasons.Values;
            _REPSeasons.DataBind();

            _REPRaces.DataSource = db.races.Where(m => m.seasonid == mRace.seasonid && m.israced == 1).OrderBy(m=>m.racenumber).ToList();
            _REPRaces.DataBind();

            BindResults();
            BindIncidents();
            //if (!IsPostBack)
            //{
                //BindSeasons();
                //BindRaces();
                
            //}
        }

        private void BindIncidents()
        {
            //var race = db.races.Where(m=>m.raceid.ToString() == _DDLRaces.SelectedValue).Single();
            var incidents = db.incidents.Where(m => m.raceid == mRace.raceid).ToList();
            
            if (incidents.Count > 0 && mRace.israceclosed == 1)
            {
                _LIIncCount.Text = incidents.Count.ToString();
                _REPIncidents.DataSource = incidents;
                _REPIncidents.ItemDataBound += _REPIncidents_ItemDataBound;
                _REPIncidents.DataBind();

                divIncidentDetails.Visible = true;
            }
            else if(mRace.israceclosed == 0)
            {
                _LINoIncidents.Text = "The stewards are still revewiing the incidents. Please come back later.";
                divIncidentDetails.Visible = false;
            }
            else
            {
                _LINoIncidents.Text = "No incidents reported this race!";
                divIncidentDetails.Visible = false;
            }
           
        }

        private void _REPIncidents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var inc = e.Item.DataItem as incident;
            var lidrivers = e.Item.FindControl("LIDrivers") as Literal;
            foreach(var driver in inc.incident_drivers)
            {
                lidrivers.Text += driver.driver.name + " | ";
            }
            lidrivers.Text = lidrivers.Text.TrimEnd(' ', '|');

            var responses = e.Item.FindControl("REPResponses") as Repeater;
            responses.DataSource = inc.incident_drivers.Where(m=> !string.IsNullOrEmpty(m.response));
            responses.DataBind();

            var stuarts = e.Item.FindControl("REPStuarts") as Repeater;
            stuarts.ItemDataBound += Stuarts_ItemDataBound;
            stuarts.DataSource = inc.incident_stuarts.Where(m=> !string.IsNullOrEmpty(m.desc));
            stuarts.DataBind();

            var finalresults = e.Item.FindControl("REPFinalResults") as Repeater;
            finalresults.DataSource = inc.incident_final_results;
            finalresults.DataBind();

            if (inc.incident_final_results.Count() == 0)
                ((Literal)e.Item.FindControl("LICAT0")).Text = "CAT0 - Racing Incident.";


            
        }


        private void Stuarts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var stuart = e.Item.DataItem as incident_stuarts;
            var represults = e.Item.FindControl("REPStuartResult") as Repeater;
            represults.DataSource = stuart.incident_stuart_result;
            represults.DataBind();
        }

        private void BindResults()
        {
            _REPResults.DataSource = db.raceresults.Where(m => m.raceid == mRace.raceid).ToList();
            _REPResults.DataBind();

            
                _IFYouTubeURL.Src = "https://www.youtube.com/embed/" +  db.races.Where(m => m.raceid == mRace.raceid).Single().youtubeurl;
        }
        //private void BindSeasons()
        //{
        //    Helpers.BindSeasonsDDL(_DDLSeasons, db);
        //}
        //private void BindRaces()
        //{
        //    string selectedValue = string.Empty;
        //    if (!IsPostBack)
        //    {
        //        var races = db.races.Where(m => m.seasonid == mRace.raceid && m.israced == 1).OrderByDescending(m => m.racenumber);
        //        if(races.Count() > 0)
        //            selectedValue = races.Take(1).Single().raceid.ToString();
        //    }

            //Helpers.BindRacesDDL(_DDLRaces, db, _DDLSeasons.SelectedValue,selectedValue,RacedOptions.RacedOnly);

        //}
        /*
        protected void _DDLSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRaces();
        }

        protected void _DDLRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindResults();
            BindIncidents();
        }
        */
    }
}