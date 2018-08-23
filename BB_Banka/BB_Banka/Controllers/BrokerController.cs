using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;
using BB_Banka.Models;

namespace BB_Banka
{

    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BrokerController : ApiController
    {
        
        // GET api/<controller>
        public List<BROKERI> GetBROKERI()
        {
            return new ServisBroker().GetBROKERI();
        }


        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public Object Post([FromBody]BROKERI value)
          
        {
            ServisBroker ser = new ServisBroker();
            int id = ser.PridejBrokera(value).id;
            byte[] data;
            string xx;




            try
            {
                var fn = HostingEnvironment.MapPath("~/App_Data/smlouva.pdf");
                data = File.ReadAllBytes(fn);
                var outFn = HostingEnvironment.MapPath("~/App_Data/Copysmlouvy.pdf");
                System.IO.File.WriteAllBytes(outFn, data);
            }
            catch (Exception e)
            {

                throw new FileNotFoundException("name", "soubor smlouvy nenalezen," +
                    " nebo soubor výstupu kopie smlouvy otevřen v jiném programu");

            }

                       

            //string data = "nutno odremovat řádek nad tím";
            return new
            {
                //stav = xx,
                extension = "pdf",
                idBrokera  = id,
                smlouva = data,
            };
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