using BB_Banka.Models;
using BB_Banka.Servisy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka.Classes
{
    public class Kontakt
    {
        
        public int id { get; set; }
        public int pozadavek_id { get; set; }
        public System.DateTime datum { get; set; }
        public int vysledek { get; set; }

        public virtual Pozadavek Pozadavky { get; set; }

        public Kontakt ToKontakt(KONTAKTY kontakt)
        {
            this.id = kontakt.id;
            this.pozadavek_id = kontakt.pozadavek_id;
            this.datum = kontakt.datum;
            this.vysledek = kontakt.vysledek;
            this.Pozadavky = new Pozadavek().ToPozadavek(kontakt.POZADAVKY);
            return this;
        }

    }

}