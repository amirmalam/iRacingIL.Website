using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iRacingIL.WebSiteWebForms
{
    public class BasePage : System.Web.UI.Page
    {
        protected iracingilEntities db = new iracingilEntities();

        protected season mSeason;

        public string Email
        {
            get {
                if (System.Configuration.ConfigurationManager.AppSettings["SimulateUserID"] != "0")
                {
                    Session["email"] = "dev@nowhere.net";
                }
                if (Session["email"] != null) return Session["email"].ToString();return string.Empty; 
            }
            set { Session["email"] = value; }
        }
        public int UserID
        {
            get {
                if (System.Configuration.ConfigurationManager.AppSettings["SimulateUserID"] != "0")
                {
                    Session["userid"] = int.Parse(System.Configuration.ConfigurationManager.AppSettings["SimulateUserID"]);
                }
                if (Session["userid"] != null) return (int)Session["userid"]; return 0; 
            }
            set { Session["userid"] = value; }
        }

        public bool IsAdmin
        {
            get
            {
                if (System.Configuration.ConfigurationManager.AppSettings["SimulateUserID"] != "0")
                {
                    Session["isadmin"] = true;
                }
                if (Session["isadmin"] != null) return (bool)Session["isadmin"]; return false;
            }
            set { Session["isadmin"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            mSeason = db.seasons.Where(m => m.iscurrentseason == 1).Single(); // TODO: Change to active season flag in db

        }
    }
}