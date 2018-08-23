using BB_Banka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka
{

    /// <summary>
    /// Třída obsluhující požadavky, které přicházejí skrze kontrolér Servis
    /// </summary>
    public class ServisBroker
    {
        private KalkulaceEntities context;

        public ServisBroker() //konstruktor, naplní kontext
        {
            context = new KalkulaceEntities(); //celá struktura databáze
        }

        public List<BROKERI> GetBROKERI()
        {
            return context.BROKERI.ToList();
        }


     


        public BROKERI PridejBrokera(BROKERI value)
        {
            BROKERI x = new BROKERI();
            x.ico = value.ico;
            x.nazev = value.nazev;
            x.aktivni = value.aktivni;
            x.start_datum = Convert.ToDateTime(value.start_datum);
            context.BROKERI.Add(x);
            context.SaveChanges();
            return x;
        }


        public BROKERI AddBroker(BROKERI Broker)
        {
            context.BROKERI.Add(Broker);
            context.SaveChanges();
            return Broker;

        }

    }
}