using BB_Banka.Servisy;
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
        [HttpGet]
        public Pozadavek Get(int id)
        {
            Pozadavek pp = new Pozadavek();
            ServisPozadavek SP = new ServisPozadavek();
            pp.id = SP.GetPozadavek(id).id;
            pp.klient_id = SP.GetPozadavek(id).klient_id;
            pp.broker_id = SP.GetPozadavek(id).broker_id;
            pp.mesice = SP.GetPozadavek(id).mesice;
            pp.castka = SP.GetPozadavek(id).castka;
            pp.rpsn = SP.GetPozadavek(id).rpsn;
            pp.poznamka = SP.GetPozadavek(id).poznamka;
            pp.spl_mesic = SP.GetPozadavek(id).spl_mesic;
            pp.spl_celkem = SP.GetPozadavek(id).spl_celkem;

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
    public class PozadPrijeti
        {

        public string telcis;
        public int pujcka;
        public int mesice;
        public string jmeno;
        public string prijmeni;
        public string poznamka;
        public int brokerid;
        public string email;
            }
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
}