using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms.aa
{

    public partial class AddRace : BasePageAutenricatedOnly
    {

        protected new void Page_Load(object sender, EventArgs e)
        {
            base.Page_Load(sender, e);

            Page.Header.Controls.Add(
new System.Web.UI.LiteralControl("<link rel=\"stylesheet\" type=\"text/css\" href=\"" + ResolveUrl("~/Content/incidents.css") + "?" + DateTime.Now.Ticks + "\" />"));


            mSeason = db.seasons.ToList()[0]; // TODO: Change to active season flag in db
            //_LASeasonName.Text = mSeason.name;

            _BTSubmit.Click += _BTSubmit_Click;

            if (!IsPostBack)
            {
                BindTracks();
                BindSeasons();
            }
        }

        private void _BTSubmit_Click(object sender, EventArgs e)
        {
            race r = new race();
            r.racenumber = int.Parse(_TBNum.Text);
            r.seasonid = int.Parse(_DDLSeasons.SelectedValue);
            r.trackid = int.Parse(_DDLTrack.SelectedValue);
            r.israced = 0;
            r.youtubeurl = _TBYouTubeURL.Text;
            r.when = DateTime.Parse(_TBWhen.Text);
            r.imgurl = string.Empty;
            r.stuartsassigned = 0;
            r.israceclosed = 0;

            db.races.Add(r);
            try
            {
                db.SaveChanges();
            }
            catch(DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();
                ex.EntityValidationErrors.ForEach(m => {
                    m.ValidationErrors.ForEach(x => {
                        sb.Append(x.PropertyName + ": " + x.ErrorMessage + " ; ");
                    });
                });

                throw new Exception(sb.ToString());
            }
        }

        private void BindTracks()
        {
            Helpers.BindTracksDDL(_DDLTrack,db,string.Empty);
            
        }
        private void BindSeasons()
        {
            Helpers.BindSeasonsDDL(_DDLSeasons, db);
        }

        protected void _DDLSeasons_SelectedIndexChanged(object sender, EventArgs e)
        {
            //BindRaces();
        }

    }
}