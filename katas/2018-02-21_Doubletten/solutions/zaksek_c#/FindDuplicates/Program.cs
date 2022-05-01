using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using FindDuplicates.Enums;
using FindDuplicates.Interfaces;

namespace FindDuplicates
{
    class Program
    {
        static void Main(string[] args)
        {
            IDublettenprüfung _dublettenprüfung = new Dublettenprüfung();

            var findBySize =_dublettenprüfung.Sammle_Kandidaten("C:\\temp");
            if (findBySize.Any())
            {
                var foundDuplicatesBySize = _dublettenprüfung.Prüfe_Kandidaten(findBySize);

                ausgabe(foundDuplicatesBySize);
            }
            
            var findyByNameAndSize =_dublettenprüfung.Sammle_Kandidaten("C:\\temp", Vergleichsmodi.Größe_und_Name);
            if (findyByNameAndSize.Any())
            {
                var foundDuplicatesBySizeAndName = _dublettenprüfung.Prüfe_Kandidaten(findyByNameAndSize);
                
                ausgabe(foundDuplicatesBySizeAndName);
            }
        }

        public static void ausgabe(IEnumerable<IDublette> foundDuplicates)
        {
            foreach (var dublette in foundDuplicates)
            {
                Console.Write("Folgende Dateien sind Identisch: ");
                foreach (var pfad in dublette.Dateipfade)
                {
                    Console.Write(pfad + " ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");
        }
    }
}
