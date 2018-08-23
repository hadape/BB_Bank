﻿using BB_Banka.Servisy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace BB_Banka
{
    public class PozadavekController : ApiController
    {
<<<<<<< HEAD
        /// <summary>
        /// hlavní controller, přijme json a předá ho servisu, který ho rozebere a naskládá do databáze
        /// </summary>
        /// <param name="a">json informací o požadavku</param>
        /// <returns>vrací objekt typu Notifiction, který obsahuje informace o požadavku</returns>
        [HttpPost]
        public Notification Get([FromBody]PozadPrijeti a)
        {
            Notification zprava = new Notification();
            try
            {
                
                ServisPozadavek SP = new ServisPozadavek();

                //příjem měsíční splátky od servisu + vyhodnocení kódu
                decimal ab = SP.PridejPozadavky(a.telcis, a.email, a.pujcka, a.mesice, a.jmeno, a.prijmeni, a.poznamka, a.brokerid);
                ab = Math.Round(ab, 2);
                //větvení, které nadefinuje proměnou zpráva(viz. řádek 21) podle kódu, který byl nastaven v instanci SP
                switch (SP.kod)
                {
                    case 1:
                        zprava.status = "Požadavek úspěšně předán.";
                        zprava.splatka = ab;
                        zprava.rpsn = (Math.Round(ServisPozadavek.rpsn, 2) - 1) * 100;
                        zprava.urok = Math.Round(SP.urok, 2);
                        break;
                    case 2:
                        zprava.status = "Půjčka byla příliš nízká.";
                        zprava.splatka = 0;
                        zprava.rpsn = 0;
                        zprava.urok = 0;
                        break;
                    case 3:
                        zprava.status = "Půjčka byla příliš vysoká.";
                        zprava.splatka = 0;
                        zprava.rpsn = 0;
                        zprava.urok = 0;
                        break;
                    case 4:
                        zprava.status = "Půjčka má příliš krátkou dobu splatnosti.";
                        zprava.splatka = 0;
                        zprava.rpsn = 0;
                        zprava.urok = 0;
                        break;
                    case 5:
                        zprava.status = "Půjčka má příliš dlouhou dobu splatnosti.";
                        zprava.splatka = 0;
                        zprava.rpsn = 0;
                        zprava.urok = 0;

                        break;
                    case 6:
                        zprava.status = "Zprostředkovatel neexistuje.";
                        zprava.splatka = 0;
                        zprava.rpsn = 0;
                        zprava.urok = 0;
                        break;
                    case 7:
                        zprava.status = "Nebylo zadáno tel. číslo.";
                        zprava.splatka = 0;
                        zprava.rpsn = 0;
                        zprava.urok = 0;
                        break;

                    default:
                        zprava.status = SP.specalmessage ;
                        zprava.splatka = 0;
                        zprava.rpsn = 0;
                        zprava.urok = 0;
                        break;
                }
               
            }
            catch (Exception e) { zprava.status = e.Message; }
            return zprava;
        }

        /// <summary>
        /// nepotřebný testovací controller pro GET požadavek 
        /// </summary>
        /// <param name="id">id požadavku,který hledáme</param>
        /// <returns>vrátí instanci požadavku</returns>
=======
        // GET api/<controller>
        [HttpPost]
        public IEnumerable<string> Get([FromBody]PozadPrijeti a)
        {
            
            ServisPozadavek SP = new ServisPozadavek();
            decimal ab=SP.PridejPozadavky(a.telcis,a.email, a.pujcka, a.mesice, a.jmeno, a.prijmeni, a.poznamka,a.brokerid);
            ab = Math.Round(ab, 2);
            return new string[] { ab.ToString()};
        }

        // GET api/<controller>/5
<<<<<<< HEAD
>>>>>>> Asi mergnute banka+pozadavek+callcentrum
=======
>>>>>>> PolishException
        [HttpGet]
        public Pozadavek Get(int id)
        {
            Pozadavek pp = new Pozadavek();
            ServisPozadavek SP = new ServisPozadavek();
            pp.id = SP.GetPozadavek(id).id;
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> PolishException
            pp.klient_id = SP.GetPozadavek(id).klient_id;
            pp.broker_id = SP.GetPozadavek(id).broker_id;
            pp.mesice = SP.GetPozadavek(id).mesice;
            pp.castka = SP.GetPozadavek(id).castka;
            pp.rpsn = SP.GetPozadavek(id).rpsn;
            pp.poznamka = SP.GetPozadavek(id).poznamka;
            pp.spl_mesic = SP.GetPozadavek(id).spl_mesic;
            pp.spl_celkem = SP.GetPozadavek(id).spl_celkem;
<<<<<<< HEAD
=======
            pp.k_id = SP.GetPozadavek(id).klient_id;
            pp.b_id = SP.GetPozadavek(id).broker_id;
            pp.doba = SP.GetPozadavek(id).mesice;
=======
            pp.klient_id = SP.GetPozadavek(id).klient_id;
            pp.broker_id = SP.GetPozadavek(id).broker_id;
            pp.mesice = SP.GetPozadavek(id).mesice;
>>>>>>> Merg-nuto, u me funguje
            pp.castka = SP.GetPozadavek(id).castka;
            pp.rpsn = SP.GetPozadavek(id).rpsn;
            pp.poznamka = SP.GetPozadavek(id).poznamka;
<<<<<<< HEAD
            pp.mes_splatka = SP.GetPozadavek(id).spl_mesic;
            pp.cel_splatka = SP.GetPozadavek(id).spl_celkem;
>>>>>>> Asi mergnute banka+pozadavek+callcentrum
=======
            pp.spl_mesic = SP.GetPozadavek(id).spl_mesic;
            pp.spl_celkem = SP.GetPozadavek(id).spl_celkem;
>>>>>>> Merg-nuto, u me funguje
=======
>>>>>>> PolishException

            return pp;
        }

        // POST api/<controller>
        /* [HttpPost]
         public void Post([FromBody]string value)
         {
         }*/

        // PUT api/<controller>/5
        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
<<<<<<< HEAD
<<<<<<< HEAD

    /// <summary>
    /// třída pro uložení přijatých atributů do instance
    /// </summary>
    public class PozadPrijeti
    {
=======
    public class PozadPrijeti
        {
>>>>>>> Asi mergnute banka+pozadavek+callcentrum
=======
    public class PozadPrijeti
        {
>>>>>>> PolishException

        public string telcis;
        public int pujcka;
        public int mesice;
        public string jmeno;
        public string prijmeni;
        public string poznamka;
        public int brokerid;
        public string email;
<<<<<<< HEAD
<<<<<<< HEAD
    }

    /// <summary>
    /// třída pro konverzi návratového typu
    /// </summary>
    //public class Pozadavek
    //{
    //    public int id;
    //    public int? b_id;
    //    public int doba;
    //    public int? k_id;
    //    public int castka;
    //    public decimal? RPSN;
    //    public string poznamka;
    //    public decimal? mes_splatka;
    //    public decimal? cel_splatka;
    //}
    public class Notification
        {
        public string status;
        public decimal splatka;
        public decimal rpsn;
        public decimal urok;
=======
            }
<<<<<<< HEAD
    public class Pozadavek
    {
        public int id;
        public int? b_id;
        public int doba;
        public int? k_id;
        public int castka;
        public decimal? RPSN;
        public string poznamka;
        public decimal? mes_splatka;
        public decimal? cel_splatka;
>>>>>>> Asi mergnute banka+pozadavek+callcentrum
    }
=======
=======
            }
>>>>>>> PolishException
    //public class Pozadavek
    //{
    //    public int id;
    //    public int? b_id;
    //    public int doba;
    //    public int? k_id;
    //    public int castka;
    //    public decimal? RPSN;
    //    public string poznamka;
    //    public decimal? mes_splatka;
    //    public decimal? cel_splatka;
    //}
<<<<<<< HEAD
>>>>>>> Merg-nuto, u me funguje
=======
>>>>>>> PolishException
}