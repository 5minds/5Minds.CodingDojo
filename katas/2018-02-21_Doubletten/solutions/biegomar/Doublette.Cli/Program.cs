namespace Doublette.Cli
{
    using System;
    using Doublette.Contracts;
    using Doublette.Implementations;

    class Program
    {
        static void Main(string[] args)
        {
            var pruefer = new Dublettenpruefung();

            var list = pruefer.Sammle_Kandidaten("files");

            foreach (var datei in list)
            {
                Console.WriteLine("Dublettensammlung");
                foreach (var pfad in datei.Dateipfade)
                {
                    Console.WriteLine(pfad);
                }
                
            }

            Console.WriteLine();
            Console.WriteLine("Dubletten nach Größe");

            var list2 = pruefer.Sammle_Kandidaten("Users/mba/source/5Minds.CodingDojo/katas/2018-02-21_Doubletten/solutions/biegomar/files", Vergleichsmodi.Size);

            foreach (var datei in list2)
            {
                Console.WriteLine("Dublettensammlung");
                foreach (var pfad in datei.Dateipfade)
                {
                    Console.WriteLine(pfad);
                }
                
            }
        }
    }
}
