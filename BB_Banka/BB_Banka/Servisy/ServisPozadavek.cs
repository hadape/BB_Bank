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

        public decimal PridejPozadavky(string telcis,string email, int pujcka, int mesice, string jmeno, string prijmeni, string poznamka)
        {
            KLIENTI a = new KLIENTI();
            a.telefon = telcis;
            a.email = email;
            Console.WriteLine(telcis);
            a.jmeno = jmeno;
            a.prijmeni = prijmeni;
            context.KLIENTI.Add(a);
            POZADAVKY p = new POZADAVKY();
            p.klient_id = a.id;
            p.castka = pujcka;
            Random rn = new Random();//smazat
            p.spl_celkem = pujcka * (decimal)rn.NextDouble();//upravit
            p.poznamka = poznamka;
            p.spl_mesic = p.spl_celkem / mesice;
           
            context.POZADAVKY.Add(p);
            
            context.SaveChanges();
            return (decimal)p.spl_mesic;
        }

    }




}