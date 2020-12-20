using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public partial class _Default : BasePage
    {
        protected new void Page_Load(object sender, EventArgs e)
        {

            base.Page_Load(sender, e);

            Page.Header.Controls.Add(
    new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/index.css") + "?" + DateTime.Now.Ticks + "\" />"));

            Page.Title = "iRacing Israel League - Homepage";

            race lastRace = Helpers.GetLastRacedRace(db);

            if (!IsPostBack && lastRace != null)
            {
                

                DataTable dt = new DataTable();
                using (SqlConnection conn = new SqlConnection(db.Database.Connection.ConnectionString))
                {
                    conn.Open();
                    using(SqlCommand comm = new SqlCommand("select * from season" + lastRace.season.number + "_standing order by champpoints desc", conn))
                    {
                        using(SqlDataAdapter adp = new SqlDataAdapter(comm))
                        {
                            adp.Fill(dt);
                        }
                       
                    }
                    conn.Close();
                }

                var dt2 = dt.Clone();
                int i = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    
                        dt2.Rows.Add(dr.ItemArray);
                    i++;
                    if (i == 5)
                        break;

                    
                }

                _REPTopStanding.DataSource = dt2;
                _REPTopStanding.DataBind();

                var nextRace = db.races.Where(m => m.seasonid == mSeason.seasonid && m.israced == 0).OrderBy(m => m.racenumber);
                if (nextRace.Count() > 0 &&  nextRace.First().when.AddHours(-6) < DateTime.Now)
                {
                    // we need to show next race becuse it less they 6 hours ahead.
                    _IFYouTubeURL.Src = "https://www.youtube.com/embed/" + nextRace.First().youtubeurl;
                    //_SPReplayTitle.InnerText = "Upcoming Race @ 22:00";
                }
                else
                {
                    _IFYouTubeURL.Src = "https://www.youtube.com/embed/" + lastRace.youtubeurl;
                    //_SPReplayTitle.InnerText = "Last Race Replay";
                }

            }
        }

        
    }
}