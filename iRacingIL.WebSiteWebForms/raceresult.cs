//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace iRacingIL.WebSiteWebForms
{
    using System;
    using System.Collections.Generic;
    
    public partial class raceresult
    {
        public int idraceresultsid { get; set; }
        public int driverid { get; set; }
        public int qualifyposition { get; set; }
        public int raceposition { get; set; }
        public int incidents { get; set; }
        public int lapscomlited { get; set; }
        public string fastlapqualify { get; set; }
        public string fastlaprace { get; set; }
        public int lapsled { get; set; }
        public string interval { get; set; }
        public int champpoints { get; set; }
        public int raceid { get; set; }
        public decimal srindex { get; set; }
        public int saftypointsaddition { get; set; }
        public int cpbase { get; set; }
        public int cpquali { get; set; }
        public int cplapsled { get; set; }
        public int cpplacegain { get; set; }
        public int cpfastestlap { get; set; }
    
        public virtual driver driver { get; set; }
        public virtual race race { get; set; }
    }
}
