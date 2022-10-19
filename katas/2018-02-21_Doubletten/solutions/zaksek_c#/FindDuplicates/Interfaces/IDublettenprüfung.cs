using System.Collections.Generic;
using FindDuplicates.Enums;

namespace FindDuplicates.Interfaces
{
    public interface IDublettenprüfung 
    {
        IEnumerable<IDublette> Sammle_Kandidaten(string pfad);

        IEnumerable<IDublette> Sammle_Kandidaten(string pfad, Vergleichsmodi modus);
 
        IEnumerable<IDublette> Prüfe_Kandidaten(IEnumerable<IDublette> kandidaten);
    }
}