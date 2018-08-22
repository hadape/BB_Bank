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
    
    public partial class POZADAVKY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public POZADAVKY()
        {
            this.KONTAKTY = new HashSet<KONTAKTY>();
        }
    
        public int id { get; set; }
        public Nullable<int> broker_id { get; set; }
        public Nullable<int> klient_id { get; set; }
        public int castka { get; set; }
        public int mesice { get; set; }
        public Nullable<int> vysledek { get; set; }
        public string poznamka { get; set; }
        public Nullable<decimal> rpsn { get; set; }
        public Nullable<decimal> spl_mesic { get; set; }
        public Nullable<decimal> spl_celkem { get; set; }
    
        public virtual BROKERI BROKERI { get; set; }
        public virtual KLIENTI KLIENTI { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<KONTAKTY> KONTAKTY { get; set; }
    }
}