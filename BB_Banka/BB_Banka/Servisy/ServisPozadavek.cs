using BB_Banka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka
{
    public class ServisPozadavek
        


    {


        /// <summary>
        /// proměnná pro uložení zprávy v případě výskytu výjimky
        /// </summary>
        public string specalmessage;
        /// <summary>
    /// číslo kódu, které rozhodne o stavu daného požadavku
    /// </summary>
        public int kod = 1;


        static Random rn = new Random();
        /// <summary>
        /// proměnná pro předání rpsn Controlleru, náhodně se 
        /// generuje vždy, když je zavolána metoda PidejPozadavky(řádek 156)
        /// </summary>
        public static decimal rpsn = (decimal)rn.NextDouble() + 1;
        /// <summary>
        /// proměnná pro předání celkového úroku Controlleru
        /// </summary>
        public decimal urok = 0;


       
        
       

        private KalkulaceEntities context;
        /// <summary>
        /// běžný bezparametrický konstruktor, vytvoří instanci databázové entity(context)
        /// </summary>
        public ServisPozadavek() 
        {
            context = new KalkulaceEntities(); //celá struktura databáze
        }
        /// <summary>
        /// metoda pro testování přítomnosti požadavků v databázi
        /// </summary>
        /// <returns>navrátí list požadavků</returns>
        public List<POZADAVKY> GetPozadavky()
        {
            return context.POZADAVKY.ToList();
        }
        /// <summary>
        /// kompletní funkce kalkulačky, roztřídí data do jednotlivých tabulek a dopočítá
        /// a dogeneruje k nim další, ověřuje platnost brokerovy smlouvy, uloženou částku
        /// a dobu splatnosti v měsících
        /// </summary>
        /// <param name="telcis">telefonní číslo</param>
        /// <param name="email">email</param>
        /// <param name="pujcka">velikost půjčky v CZK</param>
        /// <param name="mesice">doba splatnosti</param>
        /// <param name="jmeno">jméno dlužníka</param>
        /// <param name="prijmeni">příjmení dlužníka</param>
        /// <param name="poznamka">libovolný přiložený text</param>
        /// <param name="broker_id">id zprostředkovatele</param>
        /// <returns>vrátí měsíční splátku v CZK</returns>
        public decimal PridejPozadavky(string telcis,string email, int pujcka, int mesice, string jmeno, string prijmeni, string poznamka, int broker_id)
        {
            try
            {


                //kód 2: půjčka příliš nízká
                if (pujcka < 20000) { kod = 2; return 0; }
                //kód 3: půjčka příliš vysoká
                else if (pujcka > 500000) { kod = 3; return 0; }
                //kód 4: půjčka na příliš krátkou dobu
                else if (mesice < 6) { kod = 4; return 0; }
                //kód 5: půjčka na příliš dlouhou dobu
                else if (mesice > 96) { kod = 5; return 0; }
                //kód 6: broker neexistuje
                else if (context.BROKERI.Where(brok => brok.id == broker_id).FirstOrDefault() == null) { kod = 6; return 0; }
                //kód 7: nebylo zadáno tel. číslo
                else if (telcis == null) { kod = 7; return 0; }
                //pokud je vše OK, kód zůstane 1(vše OK) a data jsou předána databázi
                else
                {
                    //vytvoření klienta a naplnění jeho parametrů
                    KLIENTI a = new KLIENTI();
                    a.telefon = telcis;
                    a.email = email;
                    a.jmeno = jmeno;
                    a.prijmeni = prijmeni;

                    //inicializace pozadavku a klienta
                    POZADAVKY p = new POZADAVKY();
                    KONTAKTY k = new KONTAKTY();

                    //ověření duplicity telefonního čísla(pokud nenastane shoda, 
                    //je vytvořen nový klient, 
                    //jinak je požadavek přidělen esistujícímu klientovi)
                    bool duplikat = false;
                    foreach (KLIENTI klient in context.KLIENTI)
                    {

                        if (klient.telefon == telcis)
                        {
                            duplikat = true;
                        }
                    }
                    if (duplikat != true)
                    {
                        context.KLIENTI.Add(a);
                        p.klient_id = a.id;
                    }
                    else
                    {
                        p.klient_id = context.KLIENTI.Where(kli => kli.telefon == telcis).First().id;
                    }



                    //ověření platnosti brokerovy smlouvy
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

                    //cerna skrinka cerskrin
                    
                    //naplnění a výpočet parametrů požadavku
                    p.spl_celkem = pujcka * rpsn;
                    p.castka = pujcka;
                    p.rpsn = rpsn;
                    rpsn= (decimal)rn.NextDouble() + 1;
                    p.poznamka = poznamka;
                    p.mesice = mesice;
                    p.vysledek = 1;
                    p.spl_mesic = p.spl_celkem / mesice;
                    urok = (pujcka * rpsn) - pujcka;

                    //naplnění parametrů klienta
                    k.pozadavek_id = p.id;
                    k.vysledek = 1;
                    k.datum = DateTime.Now;

                    //naplnění tabulek(klient je přidán na řádku 76, pokud je třeba)
                    context.KONTAKTY.Add(k);
                    context.POZADAVKY.Add(p);

                    //potvrzení změn
                    context.SaveChanges();

                    //navrácení hodnoty

                    
                    return (decimal)p.spl_mesic;
                    
                }
            }
            catch (Exception e)
            {
                specalmessage = e.Message;
                kod = 999;
                return 0; }
        }

        /// <summary>
        /// testovací metoda pro vyhození požadavku podle identifikátoru
        /// </summary>
        /// <param name="id">id</param>
        /// <returns></returns>
        public POZADAVKY GetPozadavek(int id)
        {
            POZADAVKY local = context.POZADAVKY.Where(poz => poz.id == id).First();
            return local;
        }
       

    }




}
