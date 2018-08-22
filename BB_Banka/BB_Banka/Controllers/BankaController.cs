using BB_Banka.Classes;
using BB_Banka.Models;
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
    public class BankaController : ApiController
    {
        private static ServisCallCenter banka = new ServisCallCenter();
        public void GetZmenBrokera(int id, int stav)
        {
            
            banka.ZmenStavBroker(id, stav);
         
        }
        [HttpPost]
        public void Update(VstupCallCentrum vstup)
        {
            banka.UpdateData(vstup);
        }
      
    }
}