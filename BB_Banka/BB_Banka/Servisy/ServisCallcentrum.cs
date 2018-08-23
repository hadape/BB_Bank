using BB_Banka.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka.Servisy
{
    /// <summary>
    /// Třída obsluhující požadavky z controloru z CallCentra
    /// </summary>
    public class ServisCallcentrum
    {
        private KalkulaceEntities entities = new KalkulaceEntities();

        /// <summary>
        /// Získá nekontaktované požadavky
        /// </summary>
        /// <returns>List požadavků</returns>
        public List<Pozadavek> ZiskejPozadavek()
        {
            
            List<POZADAVKY> pozadavky;
            pozadavky = entities.POZADAVKY.Where(poz => poz.vysledek == 1).ToList();
            List<Pozadavek> result = new List<Pozadavek>();
            foreach (POZADAVKY p in pozadavky)
            {
                result.Add(new Pozadavek().ToPozadavek(p));
            }
            return result;
        }

        
    }
}