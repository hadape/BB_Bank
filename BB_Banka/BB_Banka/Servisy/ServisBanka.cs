﻿using BB_Banka.Classes;
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

        public string UpdateData(VstupCallCentrum vstup)
        {
            try { 
            POZADAVKY update_pozadavek = entities.POZADAVKY.Where(poz => poz.id == vstup.pozadavek_id).First();
            KLIENTI update_klient = entities.KLIENTI.Where(kl => kl.id == vstup.klient_id).First();
            KONTAKTY novy_kontakt = new KONTAKTY();
                vlozDatum(vstup.datum, novy_kontakt);
                //novy_kontakt.datum = vstup.datum;
            novy_kontakt.pozadavek_id = vstup.pozadavek_id;
            novy_kontakt.vysledek = vstup.vysledek;
            entities.KONTAKTY.Add(novy_kontakt);
            update_klient.jmeno = vstup.jmeno;
            update_klient.narozen = vstup.narozen;
            update_klient.prijmeni = vstup.prijmeni;
            update_klient.rodne_cislo = vstup.rodne_cislo;
            update_klient.email = vstup.email;
            update_klient.bydliste = vstup.bydliste;
            update_pozadavek.vysledek = vstup.vysledek;
            entities.SaveChanges();
                return "Změna provedena úspěšně";
            }
            catch (InvalidOperationException e)
            {
                return e.Message;
            }
            catch (Exception e)
            {
                return e.Message;
            }

        }
        public void vlozDatum(DateTime date, KONTAKTY kont)
        {
            try {
                DateTime neplatne = new DateTime(2001, 01, 01);
                if (date==neplatne) { }
                kont.datum = date;
                }
            catch { }
        }
    }
}