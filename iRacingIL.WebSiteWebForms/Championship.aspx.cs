using MySql.Data.MySqlClient;
using Org.BouncyCastle.Math.EC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class Championship : BasePage
    {
        //protected season mSeason;
        protected season mSelectedSeason;
        protected race mRace;
        protected DataTable mMinusDropResults = new DataTable();
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(
    new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/leaderboard.css") + "?" + DateTime.Now.Ticks + "\" />"));

            incidentList.ClientIDMode = ClientIDMode.Static;

            mRace = Helpers.GetLastRacedRace(db);


            int seasonnumber = string.IsNullOrEmpty(Request.QueryString["s"]) ? mRace.season.number : int.Parse(Request.QueryString["s"]);
            int racenumber = string.IsNullOrEmpty(Request.QueryString["r"]) ? mRace.racenumber : int.Parse(Request.QueryString["r"]);

            mSelectedSeason = db.seasons.Where(m => m.number == seasonnumber).Single();

            var race = mSelectedSeason.races.Where(m => m.racenumber == racenumber);
            if (race.Count() == 1)
                mRace = race.Single();
            else
                mRace = mSelectedSeason.races.First();


            Page.Title = mRace.season.name + " - Race " + mRace.racenumber + ": " + mRace.track.name + " - iRacing Israel League";

            InitMinusDropResult();

            _REPSeasons.ItemDataBound += _REPSeasons_ItemDataBound;
            _REPSeasons.DataSource = db.seasons.ToList();
            _REPSeasons.DataBind();

            _REPRaces.ItemDataBound += _REPRaces_ItemDataBound;
            _REPRaces.DataSource = db.races.Where(m => m.seasonid == mRace.seasonid && m.israced == 1).OrderBy(m => m.racenumber).ToList();
            _REPRaces.DataBind();

            race lastRace = Helpers.GetLastRacedRace(db);

            BindStanding();
            BindRaceResult();
            BindIncidents();


            
        }

        private void InitMinusDropResult()
        {
            var top = mRace.racenumber - mRace.season.drops;
            if (top < 0)
                top = 0;
            string sql = "select t2.driverid, " +
                         "(select sum(champpoints) from( " +
                         "select top " + top + " champpoints from raceresults " +
                         "inner join races on raceresults.raceid = races.raceid " +
                         "where " +
                         "driverid = t2.driverid " +
                         "AND races.seasonid = " + mRace.seasonid + " " +
                         "order by champpoints desc " +
                         ") as t1) as points " +
                         "from drivers as t2 " +
                         "order by points DESC ";
            using (SqlCommand comm = new SqlCommand(sql,(SqlConnection)db.Database.Connection))
            {
                using(SqlDataAdapter adapter = new SqlDataAdapter(comm))
                {
                    adapter.Fill(mMinusDropResults);
                }
            }
        }

        private void _REPRaces_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            race race = (race)e.Item.DataItem;

            var webcontrol = (HtmlGenericControl)e.Item.FindControl("opt");

            webcontrol.Attributes.Add("value", "/Championship?s=" + mSelectedSeason.number + "&r=" + race.racenumber);

            if (race.racenumber == mRace.racenumber)
                webcontrol.Attributes.Add("selected", "true");
        }

        private void _REPSeasons_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            season season = (season)e.Item.DataItem;

            var webcontrol = (HtmlGenericControl)e.Item.FindControl("opt");

            webcontrol.Attributes.Add("value", "/Championship?s=" + season.number);

            if(season.seasonid == mSelectedSeason.seasonid)
                webcontrol.Attributes.Add("selected", "true");
        }

        private void BindRaceResult()
        {
                _REPResults.DataSource = db.raceresults.Where(m => m.raceid == mRace.raceid).ToList();
                _REPResults.DataBind();


                _IFYouTubeURL.Src = "https://www.youtube.com/embed/" + db.races.Where(m => m.raceid == mRace.raceid).Single().youtubeurl;
            
        }

        private void BindStanding()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(db.Database.Connection.ConnectionString))
            {
                conn.Open();
                using (SqlCommand comm = new SqlCommand($"select * from season{mRace.season.number}_standing where races > 0 order by champpoints desc", conn))
                {
                    using (SqlDataAdapter adp = new SqlDataAdapter(comm))
                    {
                        adp.Fill(dt);
                    }

                }
                conn.Close();
            }

            dt.Columns.Add("minusdrops", typeof(int));
            foreach(DataRow row in dt.Rows)
            {
                var driverid = (int)row["driverid"];
                var result = mMinusDropResults.Select("driverid = " + driverid);
                if (result.Length == 1)
                {
                    row["minusdrops"] = result[0]["points"];
                }
                else
                    row["minusdrops"] = 0;
            }

            dt.DefaultView.Sort = string.Empty;

            _REPStanding.DataSource = dt;
            _REPStanding.DataBind();


            var dt2 = dt.Clone();
            int i = 0;
            foreach (DataRow dr in dt.Rows)
            {

                dt2.Rows.Add(dr.ItemArray);
                i++;
                if (i == 5)
                    break;


            }
        }
        private void BindIncidents()
        {
            //var race = db.races.Where(m=>m.raceid.ToString() == _DDLRaces.SelectedValue).Single();
            var incidents = db.incidents.Where(m => m.raceid == mRace.raceid).ToList();

            _LIIncCount.Text = incidents.Count.ToString();

            if (incidents.Count > 0 && mRace.israceclosed == 1)
            {
                _REPIncidents.DataSource = incidents;
                _REPIncidents.ItemDataBound += _REPIncidents_ItemDataBound;
                _REPIncidents.DataBind();

                incidentList.Visible = true;
            }
            else if (mRace.israceclosed == 0)
            {
                _LINoIncidents.Text = "The stewards are still revewiing the incidents. Please come back later.";
                incidentList.Visible = false;
            }
            else
            {
                _LINoIncidents.Text = "No incidents reported this race!";
                incidentList.Visible = false;
            }

        }

        private void _REPIncidents_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var inc = e.Item.DataItem as incident;
            var lidrivers = e.Item.FindControl("LIDrivers") as Literal;
            foreach (var driver in inc.incident_drivers)
            {
                lidrivers.Text += driver.driver.name + " | ";
            }
            lidrivers.Text = lidrivers.Text.TrimEnd(' ', '|');

            var responses = e.Item.FindControl("REPResponses") as Repeater;
            responses.DataSource = inc.incident_drivers.Where(m => !string.IsNullOrEmpty(m.response));
            responses.DataBind();

            var stuarts = e.Item.FindControl("REPStuarts") as Repeater;
            stuarts.ItemDataBound += Stuarts_ItemDataBound;
            stuarts.DataSource = inc.incident_stuarts.Where(m => !string.IsNullOrEmpty(m.desc));
            stuarts.DataBind();

            var finalresults = e.Item.FindControl("REPFinalResults") as Repeater;
            finalresults.DataSource = inc.incident_final_results;
            finalresults.DataBind();

            Control ctl = e.Item.FindControl("catzero") as Control;
            ctl.Visible = inc.incident_final_results.Count() == 0 ? true : false;


            //if (inc.incident_final_results.Count() == 0)
                //((Literal)e.Item.FindControl("LICAT0")).Text = "CAT0 - Racing Incident.";



        }

        private void Stuarts_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            var stuart = e.Item.DataItem as incident_stuarts;
            var represults = e.Item.FindControl("REPStuartResult") as Repeater;
            represults.DataSource = stuart.incident_stuart_result;
            represults.DataBind();

            Control ctl = e.Item.FindControl("catzero") as Control;
            ctl.Visible = stuart.incident_stuart_result.Count() == 0 ? true : false;
        }

    }
}