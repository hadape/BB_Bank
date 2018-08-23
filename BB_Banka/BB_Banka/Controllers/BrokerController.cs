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
    /// Kontroler zprostředkují službu přidání nového brokera
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BrokerController : ApiController
    {
        //toto volání je jen pro účely ladění
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
            if (value.ico == null)
            {
                return new
                {
                    kod = 0,
                    status  = "IČO nezadáno"
                };
            }

            if (value.nazev == null)
            {
                return new
                {
                    kod = 0,
                    status = "nazev nezadán"
                };
            }

            if (value.start_datum == null)
            {
                return new
                {
                    kod = 0,
                    status = "datum začátku smluvního vztahu nezadáno"
                };
            }


            ServisBroker ser = new ServisBroker();
            int id = ser.PridejBrokera(value).id;
            byte[] data; //Třídní proměnná pole byte pro konverzi z např. PDF souboru
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

                return new
                {
                    kod = 0,
                    status = " soubor nenalezen, nebo soubor výstupu kopie smlouvy otevřen v jiném programu"
                };

            }

                       

            //string data = "nutno odremovat řádek nad tím";
            return new
            {
                status = 1,
                extension = "pdf",
                idBrokera  = id,
                smlouva = data,
            };
        }

        // PUT api/<controller>
        public void PutSmlouvaZpatky([FromBody]byte[] value)
        {
            var fn = HostingEnvironment.MapPath("~/App_Data/smlouva_zpatky.pdf");
            File.WriteAllBytes(fn, value);
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}