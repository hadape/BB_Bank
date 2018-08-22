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
        
        public void GetZmenBrokera(int id, int stav)
        {
            ServisCallCenter banka = new ServisCallCenter();
            banka.ZmenStavBroker(id, stav);
         
        }

        public void Update(Pozadavek pozadavek, Klient klient)
        {

        }
      
    }
}