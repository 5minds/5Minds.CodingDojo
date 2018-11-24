using System;
using System.Collections.Generic;
using System.IO;
using common.enumerators;
using common.interfaces;
using lib;

namespace client
{
    class Program
    {
        static void Main(string[] args)
        {
            string pfad = GetPfad(args);

            if (TestePfadGültigkeit(pfad))
            {
                Console.WriteLine($"Ungültiger Pfad: {pfad}");
                return;
            }

            PrüfeDubletten(pfad);
        }

        private static string GetPfad(string[] args)
        {
            string pfad;
            if (args.Length == 0)
            {
                pfad = Path.Combine(Environment.CurrentDirectory, @"..\testfiles");
            }
            else
            {
                pfad = Path.Combine(Environment.CurrentDirectory, args[0]);
            }

            return pfad;
        }

        private static bool TestePfadGültigkeit(string pfad)
        {
            return !Directory.Exists(pfad);
        }

        private static void PrüfeDubletten(string pfad)
        {
            Console.WriteLine($"\n\nÜberprüfe nach Dubletten: {pfad}");

            var pruefung = new Dublettenpruefung(new FileSystemDateiErmittler());

            var dublettenGroesseUndName = Pruefung1(pruefung, pfad); // Option 1: default - Name und Größe

            var dublettenGroesse = Pruefung2(pruefung, pfad); // Option 2: nur Größe

            PruefungKandidaten(pruefung, dublettenGroesse); // MD5 hash mit den Kandidaten aus letzter Prüfung
        }

        private static IEnumerable<IDublette> Pruefung1(Dublettenpruefung pruefung, string pfad)
        {
            var dubletten = pruefung.Sammle_Kandidaten(pfad);

            PrintResult("\n\nDubletten Name und Größe:\n", dubletten);

            return dubletten;
        }

        private static IEnumerable<IDublette> Pruefung2(Dublettenpruefung pruefung, string pfad)
        {
            var dubletten = pruefung.Sammle_Kandidaten(pfad, Vergleichsmodi.Größe);

            PrintResult("\n\nDubletten nur nach Größe:\n", dubletten);

            return dubletten;
        }

        private static void PruefungKandidaten(Dublettenpruefung pruefung, IEnumerable<IDublette> kandidaten)
        {
            var dubletten = pruefung.Prüfe_Kandidaten(kandidaten);

            PrintResult("\n\nDubletten nach MD5-Hash:\n", dubletten);
        }

        private static void PrintResult(string message, IEnumerable<IDublette> dubletten)
        {
            Console.WriteLine(message);

            foreach (var dublette in dubletten)
            {
                foreach (var dateiPfad in dublette.Dateipfade)
                {
                    Console.WriteLine(dateiPfad);
                }
                Console.WriteLine(new string('-', 80));
            }
        }
    }
}