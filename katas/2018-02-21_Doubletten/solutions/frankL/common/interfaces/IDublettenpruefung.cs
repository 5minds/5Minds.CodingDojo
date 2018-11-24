using System;
using System.Collections.Generic;
using common.enumerators;

namespace common.interfaces
{
    public interface IDublettenpruefung
    {
        IEnumerable<IDublette> Sammle_Kandidaten(string pfad);
        IEnumerable<IDublette> Sammle_Kandidaten(string pfad, Vergleichsmodi modus);

        IEnumerable<IDublette> Prüfe_Kandidaten(IEnumerable<IDublette> kandidaten);
    }
}