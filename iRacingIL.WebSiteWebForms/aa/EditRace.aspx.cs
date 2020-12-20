using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms.aa
{
    public partial class EditRace : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));


            _LAMessage.Text = string.Empty;
            if(!IsPostBack)
            {
                BindSeasons();
                BindRaces();
                BindRaceForm();
            }
        }

        private void BindSeasons()
        {
            Helpers.BindSeasonsDDL(_DDLSeasons, db);
        }
        private void BindRaces()
        {
            var races = db.races.Where(m => m.seasonid.ToString() == _DDLSeasons.SelectedValue).OrderBy(m => m.racenumber).ToList();
   
            Helpers.BindRacesDDL(_DDLRaces, db, _DDLSeasons.SelectedValue,RacedOptions.All);

            // Bind Repeater
            _REPRaces.DataSource = races;
            _REPRaces.DataBind();
        }

        private void BindRaceForm()
        {
            var race = db.races.Where(m => m.raceid.ToString() == _DDLRaces.SelectedValue).Single();

            _LASeasonName.Text = race.season.name;
            _TBNum.Text = race.racenumber.ToString();
            _CBIsRaced.Checked = race.israced == 0 ? false : true;
            Helpers.BindTracksDDL(_DDLTrack, db,race.trackid.ToString());
            _TBYouTubeURL.Text = race.youtubeurl;
            _TBWhen.Text = race.when.ToString("s");

            

        }
        

        protected void _DDLSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRaces();
        }

        protected void _DDLRaces_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindRaceForm();
        }

        protected void _BTSubmit_Click(object sender, EventArgs e)
        {
            if (_FURaceResult.HasFile)
            {
                // Use the InputStream to get the actual stream sent.
                TextReader csvreader = new StreamReader(_FURaceResult.PostedFile.InputStream);

                CsvHelper.CsvDataReader datareader = new CsvHelper.CsvDataReader(new CsvHelper.CsvReader(csvreader, System.Globalization.CultureInfo.CurrentCulture));

                var drivers = db.drivers.ToList();
                while (datareader.Read())
                {
                    int lapscomplited = datareader.GetInt32(18);
                    int incidents = datareader.GetInt32(19);

                    if (lapscomplited == 0 && incidents == 0)
                        continue; // User got disconnected before race start.

                    int raceposition = datareader.GetInt32(0);
                    int iracingid = datareader.GetInt32(6);
                    int qualifyposition = datareader.GetInt32(8);
                    string interval = datareader.GetString(12);
                    int lapsleds = datareader.GetInt32(13);
                    string fastracelap = datareader.GetString(16);
                    int champpoints = datareader.GetInt32(20);
                    // TODO: need to add qualify time

                    

                    raceresult r = new raceresult();
                    r.champpoints = 0;//champpoints;
                    try
                    {
                        r.driverid = drivers.Where(m => m.iracingid == iracingid).Single().driverid;
                    }
                    catch
                    {
                        driver d = new driver();
                        d.name =  datareader.GetString(7);
                        d.iracingid = iracingid;
                        d.email = string.Empty;
                        d.password = string.Empty;
                        d.saftypoints = int.Parse(System.Configuration.ConfigurationManager.AppSettings["StartingSaftyPoint"]);

                        db.drivers.Add(d);
                        db.SaveChanges();

                        r.driverid = d.driverid;
                    }
                    r.fastlapqualify = string.Empty; // TODO: WHy not in CSV?
                    r.fastlaprace = fastracelap;
                    r.interval = interval;
                    r.lapscomlited = lapscomplited;
                    r.lapsled = lapsleds;
                    r.qualifyposition = qualifyposition;
                    r.raceid = int.Parse(_DDLRaces.SelectedValue);
                    r.raceposition = raceposition;
                    r.incidents = incidents;
                    r.cpplacegain = 0;

                    db.raceresults.Add(r);

                    db.races.Where(m => m.raceid.ToString() == _DDLRaces.SelectedValue).Single().israced = 1;

                }
            }

            var race = db.races.Where(m => m.raceid.ToString() == _DDLRaces.SelectedValue).Single();
            race.israced = _CBIsRaced.Checked ? (byte)1 : (byte)0;
            race.racenumber = int.Parse(_TBNum.Text);
            race.trackid = int.Parse(_DDLTrack.SelectedValue);
            if (!string.IsNullOrEmpty(_TBWhen.Text))
                race.when = DateTime.Parse(_TBWhen.Text);
            race.youtubeurl = _TBYouTubeURL.Text;
            _LAMessage.Text = "Form saved/Result Uploaded successfully.";

            db.SaveChanges();

            Helpers.CalculateAllForRace(race, db);
        }

        protected void _BTCalcSrIndex_Click(object sender, EventArgs e)
        {
            var race = db.races.Where(m => m.raceid.ToString() == _DDLRaces.SelectedValue).Single();
            Helpers.CalculateAllForRace(race, db);
            /*
            double maxLaps = db.raceresults.Where(m => m.raceid.ToString() == _DDLRaces.SelectedValue).OrderByDescending(m => m.lapscomlited).Take(1).Single().lapscomlited;
            foreach (var r in db.raceresults.Where(m=>m.raceid.ToString() == _DDLRaces.SelectedValue))
            {
                double precent = maxLaps / (double)r.lapscomlited;
                double score = precent * (double)r.incidents;
                r.srindex = score;
            }
            db.SaveChanges();
            */
            _LAMessage.Text = "sR Index saved successfully.";
        }
    }
}