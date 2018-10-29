namespace Doublette.Contracts
{
    using System;
    using System.Collections.Generic;

    public interface IDublettenPruefung
    {
        ICollection<IDublette> Sammle_Kandidaten(string pfad);

        ICollection<IDublette> Sammle_Kandidaten(string pfad, Vergleichsmodi modus); 

        ICollection<IDublette> Pruefe_Kandidaten(ICollection<IDublette> kandidaten);
    }
}