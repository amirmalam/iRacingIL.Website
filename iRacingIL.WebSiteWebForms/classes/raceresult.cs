using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iRacingIL.WebSiteWebForms
{
    public partial class raceresult
    {
        public int PlaceGain { get { return this.qualifyposition - this.raceposition; } }
        public int PlaceGainPosition { get; set; }
    }
}