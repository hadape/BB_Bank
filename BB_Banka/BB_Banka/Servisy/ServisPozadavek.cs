using BB_Banka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka
{
    public class ServisPozadavek



    {
        private KalkulaceEntities context;

        public ServisPozadavek() //konstruktor, naplní kontext
        {
            context = new KalkulaceEntities(); //celá struktura databáze
        }

        public List<POZADAVKY> GetPozadavky()
        {
            return context.POZADAVKY.ToList();
        }

        public decimal PridejPozadavky(string telcis,string email, int pujcka, int mesice, string jmeno, string prijmeni, string poznamka, int broker_id)
        {
           
            if (pujcka < 20000 || pujcka > 500000 || mesice < 6 || mesice > 96)
            { return 0; }
            else
            {
                KLIENTI a = new KLIENTI();
                a.telefon = telcis;
                a.email = email;
                a.jmeno = jmeno;
                a.prijmeni = prijmeni;

                bool duplikat = false;
                foreach (KLIENTI klient in context.KLIENTI)
                {

                    if (klient.telefon == telcis)
                    {
                        duplikat = true;
                    }
                }
                POZADAVKY p = new POZADAVKY();
                KONTAKTY k = new KONTAKTY();
                if (duplikat != true)
                {
                    context.KLIENTI.Add(a);
                    p.klient_id = a.id;
                }
                else
                {
                    p.klient_id = context.KLIENTI.Where(kli => kli.telefon == telcis).First().id;
                }



                p.castka = pujcka;
                if

                    (
                    (DateTime.Now.Year < context.BROKERI.Where(bro => bro.id == broker_id).First().start_datum.Value.Year) ||
                    (DateTime.Now.Year == context.BROKERI.Where(bro => bro.id == broker_id).First().start_datum.Value.Year && (DateTime.Now.Month < context.BROKERI.Where(bro => bro.id == broker_id).First().start_datum.Value.Month)) ||
                    ((DateTime.Now.Year == context.BROKERI.Where(bro => bro.id == broker_id).First().start_datum.Value.Year) && (DateTime.Now.Month == context.BROKERI.Where(bro => bro.id == broker_id).First().start_datum.Value.Month) && (DateTime.Now.Day < context.BROKERI.Where(bro => bro.id == broker_id).First().start_datum.Value.Day))
                    )
                {
                    p.broker_id = 1;
                }
                else if (context.BROKERI.Where(bro => bro.id == broker_id).First().aktivni == 0)
                {

                    p.broker_id = 1;
                }

                else
                {
                    p.broker_id = context.BROKERI.Where(bro => bro.id == broker_id).First().id;

                }
                Random rn = new Random();
                decimal cerskrin = (decimal)rn.NextDouble()+1;
                p.spl_celkem = pujcka * cerskrin;
                p.rpsn = cerskrin;
                p.poznamka = poznamka;
                p.mesice = mesice;
                p.vysledek =1;
                p.spl_mesic = p.spl_celkem / mesice;
                k.pozadavek_id = p.id;
                k.vysledek = 1;
                k.datum = DateTime.Now;

                context.KONTAKTY.Add(k);
                context.POZADAVKY.Add(p);

                context.SaveChanges();
                return (decimal)p.spl_mesic;
            }
        }
        public POZADAVKY GetPozadavek(int id)
        {
            POZADAVKY local = context.POZADAVKY.Where(poz => poz.id == id).First();
            return local;
        }
       

    }




}