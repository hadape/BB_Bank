using BB_Banka.Servisy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BB_Banka
{
    /// <summary>
    /// Kontrolér zprostředkující  reporty dle zadaných kritérií
    /// </summary>
    public class ReportController : ApiController
    {
        // GET api/<controller>/id
        // id rozhoduje o typu reportu 1 věk, 2 broker, 3 částka
        public object Get(string id)
        {
            try
            {
                return new ServisReport().GetReport(id).ToList();
            } catch (InvalidReport)
            {
                return new
                {
                    kod = 0,
                    status = " zadán požadavek na neexistující report"
                };
            }
        }



        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}