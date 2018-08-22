using BB_Banka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka.Classes
{
    public class Broker
    {
        public int id { get; set; }
        public Nullable<int> ico { get; set; }
        public Nullable<System.DateTime> start_datum { get; set; }
        public Nullable<int> aktivni { get; set; }
        public string nazev { get; set; }
        public string soubor { get; set; }

        public Broker ToBroker(BROKERI broker)
        {
            this.id = broker.id;
            this.ico = broker.ico;
            this.start_datum = broker.start_datum;
            this.aktivni = broker.aktivni;
            this.nazev = broker.nazev;
            this.soubor = broker.soubor;


            return this;
        }

    }
}