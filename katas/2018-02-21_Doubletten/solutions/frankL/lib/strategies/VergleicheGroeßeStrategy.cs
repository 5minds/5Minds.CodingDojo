using System;
using System.Collections.Generic;
using common.interfaces;
using lib.models;

namespace lib.strategies
{
    public class VergleicheGroeßeStrategy : VergleicheStrategyBase, IVergleichStrategy
    {
        public VergleicheGroeßeStrategy(IDateiErmittler dateiErmittler) : base(dateiErmittler)
        {
        }

        public IVergleichToken ErstelleToken(string dateiPfad)
        {
            var datei = DateiErmittler.ErmittleDateiInfo(dateiPfad);

            var token = new VergleichToken()
            {
                Key = datei.Groesse.ToString(),
            };

            return token;
        }
    }
}