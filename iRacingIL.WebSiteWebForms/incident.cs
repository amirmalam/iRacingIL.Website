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
    
    public partial class incident
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public incident()
        {
            this.incident_drivers = new HashSet<incident_drivers>();
            this.incident_final_results = new HashSet<incident_final_results>();
            this.incident_stuarts = new HashSet<incident_stuarts>();
        }
    
        public int incidentid { get; set; }
        public int raceid { get; set; }
        public int reporterid { get; set; }
        public int lap { get; set; }
        public string turn { get; set; }
        public string desc { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<incident_drivers> incident_drivers { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<incident_final_results> incident_final_results { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<incident_stuarts> incident_stuarts { get; set; }
        public virtual race race { get; set; }
        public virtual driver driver { get; set; }
    }
}
