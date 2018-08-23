using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BB_Banka.Classes
{
    /// <summary>
    /// Uchovává informace o úspěšnosti provedení příkazů
    /// </summary>
    public class KeeperStatus
    {
        public int Kod { get; set; } = 1;
        public string Status { get; set; } = "Vše proběhlo ok";
        
    }
}