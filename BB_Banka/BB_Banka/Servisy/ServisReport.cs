using BB_Banka.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;

namespace BB_Banka.Servisy
{

    class InvalidReport : Exception { }

    /// <summary>
    /// třída poskytující reporty dle požadovaných kategorií
    /// </summary>
    public class ServisReport
    {

        private KalkulaceEntities context;

        public ServisReport() //konstruktor, naplní kontext
        {
            context = new KalkulaceEntities(); //celá struktura databáze
        }
        /// <summary>
        /// Metoda vypisující požadované reporty z požadavků klientů.
        /// </summary>
        /// <param name="id">Druh tiskové sestavy, provoláván z kontroléru.</param>
        /// <returns></returns>
        /// <exception cref="InvalidReport">vyvolá se výjimka pokud id není platný typ reportu</exception>
        public IEnumerable<Object> GetReport(string id)

        {
            IQueryable<IGrouping<string, POZADAVKY>> grps;
            var poz = context.POZADAVKY;
            if (id == "dlebrokera") grps = poz.GroupBy(p => p.broker_id.ToString());
            else if (id == "dleveku") grps = poz.Select(p => new { Vek = EntityFunctions.DiffYears(p.KLIENTI.narozen, DateTime.Now), Pozadavek = p })
                    .GroupBy(itm => itm.Vek < 30 ? "0-29" : itm.Vek < 60 ? "30-59" : "59+", itm => itm.Pozadavek);
            else if (id == "dlepujcky") grps = poz.GroupBy(p => p.castka < 200000 ? "0-200 000" : p.castka < 300000 ? "200 000 - 300 000" :
                                                    p.castka < 500000 ? "300 000 - 500 000" : "500 000+");
            else throw new InvalidReport();

            var stats = grps.Select(g => new {
                Group = g.Key,
                Total = g.Sum(p => p.castka), // nebo Average místo Sum
                Count = g.Count()
            }).ToList();

            var labels = stats.Select(g => g.Group);
            var data1 = stats.Select(g => g.Total);
            var data2 = stats.Select(g => g.Count);

            var fn = HostingEnvironment.MapPath("~/App_Data/report_template.html");
            var outFn = HostingEnvironment.MapPath("~/App_Data/report.html");
            var html = File.ReadAllText(fn);

            //převede do jsona
            var labelsJson = JsonConvert.SerializeObject(labels);
            var dataJson = JsonConvert.SerializeObject(new List<Object> { data1, data2 });

            html = html.Replace("$LABELS$", labelsJson);
            html = html.Replace("$DATA$", dataJson);

            File.WriteAllText(outFn, html);

            return stats;

        }

   
    }
}