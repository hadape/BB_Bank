using BB_Banka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka
{
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