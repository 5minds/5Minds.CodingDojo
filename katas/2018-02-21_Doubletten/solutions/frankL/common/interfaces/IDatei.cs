using System;
using System.IO;

namespace common.interfaces
{
    public interface IDatei
    {
        string Dateiname { get; set; }
        string Pfad { get; set; }
        long Groesse { get; set; }
    }
}
