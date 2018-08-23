using BB_Banka.Classes;
using BB_Banka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka.Servisy
{
    /// <summary>
    /// Třída požadavky pro konvertování z EF
    /// </summary>
    public class Pozadavek
    {
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
        public virtual Broker Broker { get; set; }
        public virtual Klient Klient { get; set; }


        /// <summary>
        /// Přetypovává objekt POZADAVKY z EF na třídu Pozadavky
        /// </summary>
        /// <param name="pozadavek">Objekt typu POZADAVKY na přetypování</param>
        /// <returns>Vrátí přetypovaný požadavek, objekt Pozadavek</returns>
        public Pozadavek ToPozadavek(POZADAVKY pozadavek)
        {
            
            this.id = pozadavek.id;
            this.Broker = new Broker().ToBroker(pozadavek.BROKERI);
            this.broker_id = pozadavek.broker_id;
            this.castka = pozadavek.castka;
            this.Klient = new Klient().ToKlient(pozadavek.KLIENTI);
            this.klient_id = pozadavek.klient_id;
            this.mesice = pozadavek.mesice;
            this.poznamka = pozadavek.poznamka;
            this.rpsn = pozadavek.rpsn;
            this.spl_celkem = pozadavek.spl_celkem;
            this.spl_mesic = pozadavek.spl_mesic;
            this.vysledek = pozadavek.vysledek;
            return this;
        }

    }
}