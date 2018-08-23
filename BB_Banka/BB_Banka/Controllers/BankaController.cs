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
    /// <summary>
    /// Třída, která příjmá vstupy a odesílá vyýstupy
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    public class BankaController : ApiController
    {
        private static ServisCallCenter banka = new ServisCallCenter();
        /// <summary>
        /// Volá metodu ze servisy pro změnu stavu brokera
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <param name="stav">Stav brokera</param>
        /// <returns>Object KeeperStatus</returns>
        /// <exception cref="Exception"></exception>
        public KeeperStatus GetZmenStavBroker(int id, int stav)
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
        /// <summary>
        /// Updates the specified vstup.
        /// </summary>
        /// <param name="vstup">JSON</param>
        /// <returns>Object KeeperStatus</returns>
        [HttpPost]
        public KeeperStatus Update(VstupCallCentrum vstup)
        {
            return banka.UpdateData(vstup);
        }
      
    }
}