//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BB_Banka.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    
    public partial class BROKERI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public BROKERI()
        {
            this.POZADAVKY = new HashSet<POZADAVKY>();
        }
    
        public int id { get; set; }
        public Nullable<int> ico { get; set; }
        public Nullable<System.DateTime> start_datum { get; set; }
        public Nullable<int> aktivni { get; set; }
        public string nazev { get; set; }
        public string soubor { get; set; }
        [JsonIgnore]
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POZADAVKY> POZADAVKY { get; set; }
    }
}
