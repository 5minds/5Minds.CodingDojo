using System.Collections.Generic;
using common.enumerators;
using common.interfaces;
using lib.strategies;
using System.Linq;
using lib.models;

namespace lib
{
    public class Dublettenpruefung : IDublettenpruefung
    {
        public Dublettenpruefung(IDateiErmittler dateiErmittler)
        {
            DateiErmittler = dateiErmittler;
        }

        protected IDateiErmittler DateiErmittler { get; set; }

        public IEnumerable<IDublette> Prüfe_Kandidaten(IEnumerable<IDublette> kandidaten)
        {
            var groups = new Dictionary<string, IDublette>();

            var vergleichStrategy = VergleichStrategyFactory.ErstelleVergleich(Vergleichsmodi.Hash, DateiErmittler);

            foreach (IDublette kandidat in kandidaten)
            {
                var subGroup = VergleicheUndErstelleGruppen(kandidat.Dateipfade, vergleichStrategy);

                foreach (var group in subGroup)
                {
                    if (groups.ContainsKey(group.Key))
                    {
                        groups[group.Key].Dateipfade.Concat(group.Value.Dateipfade);
                    }
                    else
                    {
                        groups.Add(group.Key, group.Value);
                    }
                }
            }

            return groups.Where(group => group.Value.Dateipfade.Count > 1).Select(group => group.Value).ToList();
        }

        public IEnumerable<IDublette> Sammle_Kandidaten(string pfad)
        {
            return Sammle_Kandidaten(pfad, Vergleichsmodi.Default);
        }

        public IEnumerable<IDublette> Sammle_Kandidaten(string pfad, Vergleichsmodi modus)
        {
            var vergleichStrategy = VergleichStrategyFactory.ErstelleVergleich(modus, DateiErmittler);

            var dateiPfade = DateiErmittler.ErmittleDateien(pfad);

            var groups = VergleicheUndErstelleGruppen(dateiPfade, vergleichStrategy);

            return groups.Where(group => group.Value.Dateipfade.Count > 1).Select(group => group.Value).ToList();
        }

        private Dictionary<string, IDublette> VergleicheUndErstelleGruppen(IEnumerable<string> dateiPfade, IVergleichStrategy vergleichStrategy)
        {
            var groups = new Dictionary<string, IDublette>();

            foreach (var dateiPfad in dateiPfade)
            {
                var token = vergleichStrategy.ErstelleToken(dateiPfad);

                if (!groups.ContainsKey(token.Key))
                {
                    groups.Add(token.Key, new Dublette());
                }

                groups[token.Key].Dateipfade.Add(dateiPfad);
            }

            return groups;
        }
    }
}