using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iRacingIL.Website.Models
{
    public class Incident
    {
        public int IncidentID { get; set; }
        public int RaceID { get; set; }
        public int ReporterID{get;set;}
        public int Lap { get; set; }
        public string Turn { get; set; }
        public int DriverID { get; set; }
        public string Desc { get; set; }

    }
}
