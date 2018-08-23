
using BB_Banka;
using NUnit.Framework;
using System;


namespace TestKalkulace
{
    [TestFixture]
    class TestKalkulace
    {
        private ServisPozadavek pc;
        private PozadPrijeti pp;
        [SetUp]
        public void nastav()
        {
            pc = new ServisPozadavek();
            pp = new PozadPrijeti();
        }
        [Test]
        public void testSpravneUdaje()
        {

          decimal vys=  pc.PridejPozadavky("777777777", "abcmail", 300002, 15, "Testuju", "Program", "pozn.", 1);
            Assert.That(vys, Is.EqualTo((300000*ServisPozadavek.rpsn)/15));
           

        }

    }
}
