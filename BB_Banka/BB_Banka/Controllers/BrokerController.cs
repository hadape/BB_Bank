using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Hosting;

namespace BB_Banka
{
    public class BrokerController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public Object Post([FromBody]string value)
        {
            var fn = HostingEnvironment.MapPath("~/App_Data/smlouva.pdf");
            byte[] data = File.ReadAllBytes(fn);
            return new
            {
                extension = "pdf",
                id = -1,
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