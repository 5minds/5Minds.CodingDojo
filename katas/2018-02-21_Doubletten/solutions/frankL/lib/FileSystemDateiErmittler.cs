using System.Collections.Generic;
using System.IO;
using common.interfaces;
using lib.models;

namespace lib
{
    public class FileSystemDateiErmittler : IDateiErmittler
    {
        public IEnumerable<string> ErmittleDateien(string pfad)
        {
            var dateiPfade = new List<string>();

            dateiPfade.AddRange(Directory.GetFiles(pfad));

            foreach (string ordner in Directory.GetDirectories(pfad))
            {
                dateiPfade.AddRange(ErmittleDateien(ordner));
            }

            return dateiPfade;
        }

        public IDatei ErmittleDateiInfo(string dateiPfad)
        {
            var fileInfo = new FileInfo(dateiPfad);

            return new Datei()
            {
                Dateiname = Path.GetFileName(dateiPfad),
                Pfad = dateiPfad,
                Groesse = fileInfo.Length
            };
        }

        public byte[] LeseInhalt(string dateiPfad)
        {
            if (File.Exists(dateiPfad))
            {
                return File.ReadAllBytes(dateiPfad);
            }
            else
            {
                return null;
            }
        }
    }
}