using System;

namespace common.interfaces
{
    public interface IVergleichStrategy
    {
        IVergleichToken ErstelleToken(string dateiPfad);
    }
}
