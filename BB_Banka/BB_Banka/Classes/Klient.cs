﻿using BB_Banka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka.Classes
{
    public class Klient
    {
        public int id { get; set; }
        public string telefon { get; set; }
        public string jmeno { get; set; }
        public string prijmeni { get; set; }
        public string email { get; set; }
        public string bydliste { get; set; }
        public Nullable<System.DateTime> narozen { get; set; }
        public string rodne_cislo { get; set; }

        public Klient ToKlient (KLIENTI klient)
        {
            this.id = klient.id;
            this.telefon = klient.telefon;
            this.jmeno = klient.jmeno;
            this.prijmeni = klient.prijmeni;
            this.email = klient.email;
            this.bydliste = klient.bydliste;
            this.narozen = klient.narozen;
            this.rodne_cislo = klient.rodne_cislo;
            return this;
        }
    }
}