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
    
    public partial class incident_stuart_result
    {
        public int incident_stuart_resultid { get; set; }
        public int incident_stuartid { get; set; }
        public int driverid { get; set; }
        public int cat { get; set; }
    
        public virtual driver driver { get; set; }
        public virtual incident_stuarts incident_stuarts { get; set; }
    }
}