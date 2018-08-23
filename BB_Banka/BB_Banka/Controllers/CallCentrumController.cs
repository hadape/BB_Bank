<<<<<<< HEAD
﻿using BB_Banka.Classes;
using BB_Banka.Models;
=======
﻿using BB_Banka.Models;
>>>>>>> servis_banka, servis call centrum, az do update hotovo
using BB_Banka.Servisy;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BB_Banka
{
    public class CallCentrumController : ApiController
    {
        private static ServisCallcentrum callcentrum = new ServisCallcentrum();
<<<<<<< HEAD
        private static ServisCallCenter banka = new ServisCallCenter();

        public List<Pozadavek> GetPozadavky()
        {
            
            return callcentrum.ZiskejPozadavek();
        }
        [HttpPost]
        public void Update(VstupCallCentrum vstup)
        {
            banka.UpdateData(vstup);
=======
        
        public List<Pozadavek> GetPozadavky()
        {
            
            //List<POZADAVKY> result = callcentrum.ZiskejPozadavek();
            //string vysledek = null;
            //foreach (POZADAVKY p in result)
            //{
            //    vysledek += $"Pozadavek id: {p.id}, Castka: {p.castka} /n Klient Jmeno: {p.KLIENTI.jmeno} Telefon: {p.KLIENTI.telefon}";
            //}
            return callcentrum.ZiskejPozadavek();
>>>>>>> servis_banka, servis call centrum, az do update hotovo
        }
    }
}