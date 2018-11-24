using System;
using System.Linq;
using common.enumerators;
using common.interfaces;
using lib;
using lib.strategies;
using Xunit;

namespace test
{
    public class DublettenTest
    {
        [Fact]
        public void TestNurGroesseStrategy()
        {
            var pfad = @"inMemory";
            var dateiErmittler = new InMemoryDateiErmittler();
            var pruefung = new Dublettenpruefung(dateiErmittler);

            // act
            var dubletten = pruefung.Sammle_Kandidaten(pfad, Vergleichsmodi.Größe);

            Assert.True(dubletten.Count() == 2, "Anzahl Dubletten beim Vergleich nur nach Größe ist falsch!");
        }

        [Fact]
        public void TestGroesseUndNameStrategy()
        {
            var pfad = @"inMemory";
            var dateiErmittler = new InMemoryDateiErmittler();
            var pruefung = new Dublettenpruefung(dateiErmittler);

            // act
            var dubletten = pruefung.Sammle_Kandidaten(pfad, Vergleichsmodi.Größe_und_Name);

            Assert.True(dubletten.Count() == 1, "Anzahl Dubletten beim Vergleich nach Größe und Name ist falsch!");
        }

        [Fact]
        public void TestMd5Strategy()
        {
            var pfad = @"inMemory";
            var dateiErmittler = new InMemoryDateiErmittler();
            var pruefung = new Dublettenpruefung(dateiErmittler);

            // act
            var dubletten = pruefung.Sammle_Kandidaten(pfad, Vergleichsmodi.Hash);

            Assert.True(dubletten.Count() == 2, "Anzahl Dubletten beim Vergleich nach MD5-Hash ist falsch!");
        }

        [Fact]
        public void Test2PassPruefungNurGroesse()
        {
            var pfad = @"inMemory";
            var dateiErmittler = new InMemoryDateiErmittler();
            var pruefung = new Dublettenpruefung(dateiErmittler);

            // act
            var dublettenGroesseUndName = pruefung.Sammle_Kandidaten(pfad, Vergleichsmodi.Größe);
            var dublettenMd5 = pruefung.Prüfe_Kandidaten(dublettenGroesseUndName);

            Assert.True(dublettenMd5.Count() == 2, "Anzahl Dubletten bei der 2-Pass Prüfung (nur Größe) ist falsch!");
        }

        [Fact]
        public void Test2PassPruefungGroesseUndName()
        {
            var pfad = @"inMemory";
            var dateiErmittler = new InMemoryDateiErmittler();
            var pruefung = new Dublettenpruefung(dateiErmittler);

            // act
            var dublettenGroesseUndName = pruefung.Sammle_Kandidaten(pfad, Vergleichsmodi.Größe_und_Name);
            var dublettenMd5 = pruefung.Prüfe_Kandidaten(dublettenGroesseUndName);

            Assert.True(dublettenMd5.Count() == 1, "Anzahl Dubletten bei der 2-Pass Prüfung (Größe und Name) ist falsch!");
        }
    }
}
