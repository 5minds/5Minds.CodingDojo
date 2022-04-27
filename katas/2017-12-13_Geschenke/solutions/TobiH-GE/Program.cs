using System;
using System.Collections.Generic;

namespace Geschenke
{
    // https://github.com/TobiH-GE/5Minds.CodingDojo/tree/develop/katas/2017-12-13_Geschenke
    // Geschenke!
    //Der Weihnachtsmann liefert Geschenke an Häuser in einer zwei-dimensionalen Grid-Welt.
    //Er beginnt mit der Auslieferung an seinem Startpunkt.Danach gibt ihm ein Elf vom Nordpol per Smartphone die neue Position an.
    //Eine neue Position liegt immer exakt ein Haus im Norden (^), im Süden(v), im Osten(>) oder im Westen(<).
    //Nach jedem Schritt wird ein Paket ausgeliefert.

    //Einschränkung
    //Dummerweise ist der Elf zu lange am Glühweinstand des Buerer Weihnachtsmarktes gewesen und hat die exakte Route nicht immer parat.Daher kann es vorkommen, dass der Weihnachtsmann - sehr zur Freude der Kinder - ein Haus auch mehrfach besucht.

    //Die Aufgabe
    //Wie viele Häuser hat der Weihnachtsmann auf der jeweiligen Gesamtroute mindestens einmal besucht? Eine Route entspricht einer Zeile in der Quelldatei.

    //Beispiele
    // ">" liefert Geschenke an zwei Häuser: eines am Startpunkt und eines im Osten. "^>v<" liefert Geschenke an vier Häuser im Quadrat.Der Startpunkt erhält sogar zwei Geschenke. "^v^v^v^v^v" liefert eine ganze Menge Geschenke an einige glückliche Kinder in nur zwei Häusern.

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Wieviele Häuser erhalten Geschenke?");

            string[] Routen = new string[]
            {
                "<><><>^v",
                ">",
                "^>v<",
                "^v^v^v^v^v"
            };

            foreach (var route in Routen)
            {
                Console.WriteLine("Mit Route " + route + " erhalten " + Analyse.AnzahlHaeuser(route) + " Häuser Geschenke!");
            }
        }
    }

    public static class Analyse
    {
        public static int AnzahlHaeuser(string route)
        {
            Dictionary<Tuple<int, int>, int> HaeuserPositionen = new Dictionary<Tuple<int,int>, int>();

            int x = 0;
            int y = 0;

            for (int i = 0; i < route.Length; i++)
            {
                string value = route.Substring(i, 1);

                switch (value)
                {
                    case "<":
                        x--;
                        break;
                    case ">":
                        x++;
                        break;
                    case "^":
                        y--;
                        break;
                    case "v":
                        y++;
                        break;
                    default:
                        Console.WriteLine("Fehler in der Route!");
                        return 0;
                }

                if (HaeuserPositionen.ContainsKey(new Tuple<int, int>(x, y)))
                {
                    HaeuserPositionen[new Tuple<int, int>(x, y)]++;
                }
                else
                {
                    HaeuserPositionen.Add(new Tuple<int, int>(x, y), 1);
                }

            }

            return HaeuserPositionen.Count;
        }
    }
}
