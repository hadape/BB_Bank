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
    using System;
    using System.Collections.Generic;
    
    public partial class KLIENTI
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KLIENTI()
        {
            this.POZADAVKY = new HashSet<POZADAVKY>();
        }
    
        public int id { get; set; }
        public string telefon { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string email { get; set; }
        public string bydliste { get; set; }
        public Nullable<System.DateTime> narozen { get; set; }
        public string rodne_cislo { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<POZADAVKY> POZADAVKY { get; set; }
    }
}
