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
        public KeeperStatus GetZmenBrokera(int id, int stav)
        {
            KeeperStatus status = new KeeperStatus();
            try
            {
                
                if (!(stav == 0 || stav == 1))
                {

                    throw new Exception($"Změna stavu brokera {id} {(banka.VratBrokera(id).nazev)} neproběhla, stav brokera nebyl ve správném tvaru, 1-aktivní, 0-neaktivní");
                }

                banka.ZmenStavBroker(id, stav);
                return status;
            }
            catch (InvalidOperationException)
            {
                status.Kod = 0;
                status.Status = $"Zadané ID ({id}) brokera neexistuje v databázi";
                return status;
            }
            catch (Exception e){
                status.Kod = 0;
                status.Status = e.Message;
                return status;
            }
            

        }
        [HttpPost]
        public KeeperStatus Update(VstupCallCentrum vstup)
        {
            KeeperStatus status = new KeeperStatus();
            banka.UpdateData(vstup);
            return status;
        }
      
    }
}