using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI.WebControls;

namespace iRacingIL.WebSiteWebForms
{
    public enum RacedOptions { RacedOnly, NotRacedOnly, All}
    public static class Helpers
    {
        public static void BindTracksDDL(DropDownList ddl, iracingilEntities db,string selectedvalue)
        {
            ddl.Items.Clear();
            foreach (track t in db.tracks.OrderBy(m => m.name))
            {
                var li = new ListItem(t.name + " - " + t.config, t.trackid.ToString());
                if (!string.IsNullOrEmpty(selectedvalue) && li.Value == selectedvalue)
                    li.Selected = true;
                ddl.Items.Add(li);
            }
        }
        public static void BindSeasonsDDL(DropDownList ddl, iracingilEntities db)
        {
            var currents = db.seasons.Where(m => m.iscurrentseason == 1).Single().seasonid;
            BindSeasonsDDL(ddl, db, currents.ToString());
        }
        public static void BindSeasonsDDL(DropDownList ddl, iracingilEntities db,string selectedvalue)
        {
            ddl.Items.Clear();
            foreach (var s in db.seasons.OrderBy(m => m.name))
            {
                var li = new ListItem(s.name, s.seasonid.ToString());
                if (li.Value == selectedvalue)
                    li.Selected = true;
                ddl.Items.Add(li);
            }
        }
        public static void BindRacesDDL(DropDownList ddl,iracingilEntities db,string seasonid,RacedOptions racedoptions)
        {
            var races = db.races.Where(m => m.seasonid.ToString() == seasonid).OrderBy(m => m.racenumber).ToList();
            
            foreach (var s in races)
            {
                if (s.israced == 0)
                {
                    BindRacesDDL(ddl, db, s.seasonid.ToString(),s.raceid.ToString(),racedoptions);
                    break;
                }
            }
        }
        public static void BindRacesDDL(DropDownList ddl,iracingilEntities db,string seasonid,string selectedvalue, RacedOptions racedoptions)
        {
            var races = db.races.Where(m => m.seasonid.ToString() == seasonid).OrderBy(m => m.racenumber).ToList();

            // Create DDL
            ddl.Items.Clear();
            foreach (var s in races)
            {
                if (racedoptions == RacedOptions.All ||
                    (racedoptions == RacedOptions.RacedOnly && s.israced == 1) ||
                    (racedoptions == RacedOptions.NotRacedOnly && s.israced == 0))
                {
                    ListItem li = new ListItem($"{s.racenumber} = {s.track.name}", s.raceid.ToString());
                    if (li.Value == selectedvalue)
                    {
                        li.Selected = true;
                    }
                    ddl.Items.Add(li);
                }
            }
        }

        public static void SendEmail(string to, string subject, string body)
        {
            SendEmail(new string[] { to }, subject, body);
        }

        public static void SendEmail(string[] to, string subject, string body)
        {
            string host = System.Configuration.ConfigurationManager.AppSettings["smtp:host"];
            string password = System.Configuration.ConfigurationManager.AppSettings["smtp:password"];
            int port = int.Parse( System.Configuration.ConfigurationManager.AppSettings["smtp:port"]);
            bool isssl = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["smtp:isssl"]);
            bool isDev = bool.Parse(System.Configuration.ConfigurationManager.AppSettings["smtp:isdev"]);
            MailMessage email = new MailMessage();

            if (!isDev)
            {
                foreach (string str in to)
                    email.To.Add(str);
            }
            else
                email.To.Add("782amir@gmail.com");

            email.From = new MailAddress("noreply@iilracing.com");
            email.Subject = subject;
            email.Body = body;

            SmtpClient client = new SmtpClient();
            client.Host = host;
            client.Port = port;
            client.EnableSsl = isssl;
            client.Credentials = new NetworkCredential("apikey", password);
            

            client.Send(email);
        }

        public static race GetLastRacedRace(iracingilEntities db)
        {
            var races = db.races.Where(m => m.israced == 1).OrderByDescending(m=>m.when);
            if (races.Count() > 0)
                return races.Take(1).Single();
            else
                return null;
        }

        public static void CalculateAllForRace(race r, iracingilEntities db)
        {
            double maxLaps = db.raceresults.Where(m => m.raceid == r.raceid).OrderByDescending(m => m.lapscomlited).Take(1).Single().lapscomlited;
            var raceresultsordered = r.raceresults.OrderByDescending(m => m.PlaceGain).ThenBy(m => m.qualifyposition).ToList();
            for (int i = 0; i < raceresultsordered.Count(); i++)
                raceresultsordered[i].PlaceGainPosition = i + 1;


            foreach (var result in raceresultsordered)
            {
                CalucluateChampPoints(result);
                //CalucluateAltChampPoints(result);
                CalculateSRIndex(result, maxLaps);
            }

            db.SaveChanges();
        }

        /*
        private static void CalcuateChampPoints(raceresult r)
        {
            int final = 0;
            switch (r.raceposition)
            {
                case 1:
                    final = 25;
                    break;
                case 2:
                    final = 18;
                    break;
                case 3:
                    final = 15;
                    break;
                case 4:
                    final = 12;
                    break;
                case 5:
                    final = 10;
                    break;
                case 6:
                    final = 8;
                    break;
                case 7:
                    final = 6;
                    break;
                case 8:
                    final = 4;
                    break;
                case 9:
                    final = 2;
                    break;
                case 10:
                    final = 1;
                    break;
            }

            r.champpoints = final;
        }
        */
        private static void CalucluateChampPoints(raceresult r)
        {
            /// CULC BASE POINTS (By Position)
            int basepoints = 0;
            switch (r.raceposition)
            {
                case 1:
                    basepoints = 40;
                    break;
                case 2:
                    basepoints = 37;
                    break;
                case 3:
                    basepoints = 34;
                    break;
                case 4:
                    basepoints = 32;
                    break;
                case 5:
                    basepoints = 30;
                    break;
                case 6:
                    basepoints = 29;
                    break;
                case 7:
                    basepoints = 28;
                    break;
                case 8:
                    basepoints = 27;
                    break;
                case 9:
                    basepoints = 26;
                    break;
                case 10:
                    basepoints = 25;
                    break;
                case 11:
                    basepoints = 24;
                    break;
                case 12:
                    basepoints = 23;
                    break;
                case 13:
                    basepoints = 22;
                    break;
                case 14:
                    basepoints = 21;
                    break;
                case 15:
                    basepoints = 20;
                    break;
                case 16:
                    basepoints = 19;
                    break;
                case 17:
                    basepoints = 18;
                    break;
                case 18:
                    basepoints = 17;
                    break;
                case 19:
                    basepoints = 16;
                    break;
                case 20:
                    basepoints = 15;
                    break;
                case 21:
                    basepoints = 14;
                    break;
                case 22:
                    basepoints = 13;
                    break;
                case 23:
                    basepoints = 12;
                    break;
                case 24:
                    basepoints = 11;
                    break;
                case 25:
                    basepoints = 10;
                    break;
                case 26:
                    basepoints = 9;
                    break;
                case 27:
                    basepoints = 8;
                    break;
                case 28:
                    basepoints = 7;
                    break;
                case 29:
                    basepoints = 6;
                    break;
                case 30:
                    basepoints = 5;
                    break;
                case 31:
                    basepoints = 4;
                    break;
                case 32:
                    basepoints = 3;
                    break;
                case 33:
                    basepoints = 2;
                    break;
                case 34:
                    basepoints = 1;
                    break;
            }

            // CALC LAPS LET POINTS
            int lapsletpoints = r.lapsled > 0 ? 1 : 0;

            // CALC POLE POSITION POINTS
            int polpoints = r.qualifyposition == 1 ? 1 : 0;

            // CALC FASTEST LAP
            int fastestlappoints = r.race.raceresults.OrderBy(m => m.fastlaprace).Take(1).Single().driverid == r.driverid ? 1 : 0;

            // CALC POSITION GAIN POINTS
            int positiongainpoints = 0;
            switch (r.PlaceGainPosition)
            {
                case 1:
                    positiongainpoints = 4;
                    break;
                case 2:
                    positiongainpoints = 3;
                    break;
                case 3:
                    positiongainpoints = 2;
                    break;
                case 4:
                    positiongainpoints = 1;
                    break;
            }

            
            r.cpbase = basepoints;
            r.cplapsled = lapsletpoints;
            r.cpfastestlap = fastestlappoints;
            r.cpquali = polpoints;
            r.cpplacegain = positiongainpoints;

            r.champpoints = basepoints + lapsletpoints + fastestlappoints + polpoints + positiongainpoints ;
        }

        private static void CalculateSRIndex(raceresult r, double maxlaps)
        {
            double lapscomplited = r.lapscomlited == 0 ? 1 : r.lapscomlited;
            double precent = maxlaps / lapscomplited;
            double score = precent * (double)r.incidents;
            r.srindex = (decimal)score;
            if (r.lapscomlited < (maxlaps * 0.75))
                r.srindex = r.srindex + 10; // 10 points panelty if not complited 75 percent of race.
        }

        private static Random rng = new Random();

        public static void Shuffle<T>(this IList<T> list)
        {
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        public static string MakeMySQLSafe(this string str)
        {
            return str.Replace('“', '"').Replace('”', '"').Replace('’', '\'');
        }
    }
}