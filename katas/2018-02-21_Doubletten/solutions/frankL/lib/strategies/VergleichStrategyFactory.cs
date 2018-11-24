using System;
using common.enumerators;
using common.interfaces;

namespace lib.strategies
{
    public static class VergleichStrategyFactory
    {
        public static IVergleichStrategy ErstelleVergleich(Vergleichsmodi vergleichsmodi, IDateiErmittler dateiErmittler)
        {
            if (vergleichsmodi == Vergleichsmodi.Größe)
            {
                return new VergleicheGroeßeStrategy(dateiErmittler);
            }
            else if (vergleichsmodi == Vergleichsmodi.Größe_und_Name)
            {
                return new VergleicheNameUndGroeßeStrategy(dateiErmittler);
            }
            else if (vergleichsmodi == Vergleichsmodi.Hash)
            {
                return new VergleicheMD5Strategy(dateiErmittler);
            }
            else
            {
                throw new ArgumentException($"Invalid value for argument {nameof(vergleichsmodi)}!");
            }
        }
    }
}