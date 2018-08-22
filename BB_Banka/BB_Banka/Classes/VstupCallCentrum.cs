using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka.Classes
{
    public class VstupCallCentrum
    {
        
        public Nullable<int> broker_id { get; set; }
        public Nullable<int> klient_id { get; set; }
        public string poznamka { get; set; }
        public string telefon { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string email { get; set; }
        public string bydliste { get; set; }
        public Nullable<System.DateTime> narozen { get; set; }
        public string rodne_cislo { get; set; }
        public int pozadavek_id { get; set; }
        public System.DateTime datum { get; set; }
        public int vysledek { get; set; }
    }
}