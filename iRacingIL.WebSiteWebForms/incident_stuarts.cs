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
    
    public partial class incident_stuarts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public incident_stuarts()
        {
            this.incident_stuart_result = new HashSet<incident_stuart_result>();
        }
    
        public int idincident_stuartsid { get; set; }
        public int stuartid { get; set; }
        public int incidentid { get; set; }
        public string desc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<incident_stuart_result> incident_stuart_result { get; set; }
        public virtual incident incident { get; set; }
        public virtual driver driver { get; set; }
    }
}
