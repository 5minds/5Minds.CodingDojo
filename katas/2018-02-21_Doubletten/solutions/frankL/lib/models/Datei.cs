using System;
using System.IO;
using common.interfaces;

namespace lib.models
{
    public class Datei : IDatei
    {
        public string Dateiname { get; set; }
        public string Pfad { get; set; }
        public long Groesse { get; set; }
    }
}