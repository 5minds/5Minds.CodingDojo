using System;
using System.Collections.Generic;

namespace common.interfaces
{
    public interface IDublette
    {
        ICollection<string> Dateipfade { get; } // Anmerkung Interface-Änderung: ICollection anstelle von IEnumerable, da Werte hinzugefügt werden
    }
}
