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




        /// <summary>
        /// Pridej brokera, metoda uloží nového brokera do db.
        /// </summary>
        /// <param name="value">objekt z kontroleru, nesoucí parametry 
        /// název, ičo, den počátku spolupráce .</param>
        /// <returns> vrací </returns>
        public BROKERI PridejBrokera(BROKERI value)
        {
            BROKERI x = new BROKERI();
            x.nazev = value.nazev;
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