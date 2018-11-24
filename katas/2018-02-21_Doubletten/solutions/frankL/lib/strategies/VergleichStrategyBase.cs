using System;
using System.Collections.Generic;
using common.interfaces;
using lib.models;

namespace lib.strategies
{
    public abstract class VergleicheStrategyBase
    {
        public VergleicheStrategyBase(IDateiErmittler dateiErmittler)
        {
            DateiErmittler = dateiErmittler;
        }

        protected IDateiErmittler DateiErmittler { get; set; }
    }
}