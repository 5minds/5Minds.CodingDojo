using System.Collections.Generic;

namespace common.interfaces
{
    public interface IDateiErmittler
    {
        IEnumerable<string> ErmittleDateien(string pfad);

        IDatei ErmittleDateiInfo(string dateiPfad);

        byte[] LeseInhalt(string dateiPfad);
    }
}