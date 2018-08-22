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
            decimal ab=SP.PridejPozadavky(a.telcis,a.email, a.pujcka, a.mesice, a.jmeno, a.prijmeni, a.poznamka);
            ab = Math.Round(ab, 2);
            return new string[] { ab.ToString()};
        }

        // GET api/<controller>/5
        [HttpGet]
        public string Get(int id)
        {
            return "value";
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
}