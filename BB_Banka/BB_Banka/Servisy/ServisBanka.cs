using BB_Banka.Classes;
using BB_Banka.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka.Servisy
{
    public class ServisCallCenter
    {
        private KalkulaceEntities entities = new KalkulaceEntities();

        public void ZmenStavBroker (int id, int stav)
        {
            BROKERI zmena = entities.BROKERI.Where(brk => brk.id == id).First();
            zmena.aktivni = stav;
            entities.SaveChanges();
        }

       

        public BROKERI VratBrokera(int id)
        {

            return entities.BROKERI.Where(brk => brk.id == id).First(); 
        }

        public void UpdateData(Pozadavek pozadavek, Klient klient)
        {
            POZADAVKY update_pozadavek = entities.POZADAVKY.Where(poz => poz.id == pozadavek.id).First();
            KLIENTI update_klient = entities.KLIENTI.Where(kl => kl.id == klient.id).First();
            update_klient.jmeno = klient.jmeno;
            update_klient.narozen = klient.narozen;
            update_klient.prijmeni = klient.prijmeni;
            update_klient.rodne_cislo = klient.rodne_cislo;
            update_klient.telefon = klient.telefon;
            update_klient.email = klient.telefon;
            update_klient.bydliste = klient.bydliste;

        }
    }
}