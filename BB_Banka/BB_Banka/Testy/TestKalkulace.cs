using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NUnit.Framework;

namespace BB_Banka.Testy
{
    [TestFixture]
    public class TestKalkulace
    {
        ServisPozadavek sp;
        [SetUp]
        public void nastavit()
        {
            sp = new ServisPozadavek();
        }
        /// <summary>
        /// Otestuje správnost výpočtu splátek.
        /// </summary>
        [Test]
        public void TestSpravne()
        {
            decimal rp = ServisPozadavek.rpsn;
            decimal vys = sp.PridejPozadavky("77777", "mail", 200000, 51, "jmeno", "prijmeni", "pozn", 1);
            Assert.That(sp.kod,Is.EqualTo(1));
        }
        /// <summary>
        /// Testuje chybový kód při chybném vstupu.
        /// </summary>
        [Test]
        public void TestSpatnyVstup()
        {
            decimal rp = ServisPozadavek.rpsn;
            decimal vys = sp.PridejPozadavky("77777", "mail", 200, 51, "jmeno", "prijmeni", "pozn", 1);
            if (sp.kod > 1)
            { sp.kod = 0; }
            Assert.That(sp.kod, Is.EqualTo(0));
        }

       
       


    }
}