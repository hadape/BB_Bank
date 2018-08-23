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
<<<<<<< HEAD
        private static ServisCallCenter banka = new ServisCallCenter();
        public string GetZmenBrokera(int id, int stav)
        {
            
            try
            {
                
                if (!(stav == 0 || stav == 1))
                {

                    throw new Exception($"Změna stavu brokera {id} {(banka.VratBrokera(id).nazev)} neproběhla, stav brokera nebyl ve správném tvaru, 1-aktivní, 0-neaktivní");
                }

                banka.ZmenStavBroker(id, stav);
                return $"Změna proběhla v pořádku Broker ID:{banka.VratBrokera(id).id}" +
                    $", název:{banka.VratBrokera(id).nazev}" +
                    $",stav:{banka.VratBrokera(id).aktivni}";
            }
            catch (InvalidOperationException)
            {
                return $"Zadané ID ({id}) brokera neexistuje v databázi";
            }
            catch (Exception e){
                return e.ToString();
            }
            

        }
        [HttpPost]
        public string Update(VstupCallCentrum vstup)
        {
            return banka.UpdateData(vstup);
=======
        
        public void GetZmenBrokera(int id, int stav)
        {
            ServisCallCenter banka = new ServisCallCenter();
            banka.ZmenStavBroker(id, stav);
         
        }

        public void Update(Pozadavek pozadavek, Klient klient)
        {

>>>>>>> servis_banka, servis call centrum, az do update hotovo
        }
      
    }
}