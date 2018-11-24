using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using common.interfaces;
using lib.models;

namespace test
{
    public class InMemoryDateiErmittler : IDateiErmittler
    {
        public IEnumerable<string> ErmittleDateien(string pfad)
        {
            var dateiPfade = new List<string>();

            dateiPfade.Add(Path.Combine(pfad, @"test1.dat"));
            dateiPfade.Add(Path.Combine(pfad, @"test2.dat"));
            dateiPfade.Add(Path.Combine(pfad, @"_xyz.dat"));
            dateiPfade.Add(Path.Combine(pfad, @"subfolder\test1.dat"));
            dateiPfade.Add(Path.Combine(pfad, @"subfolder\abc_xyz.dat"));

            return dateiPfade;
        }

        public IDatei ErmittleDateiInfo(string dateiPfad)
        {
            var fileInfo = new FileInfo(dateiPfad);

            var datei = new Datei()
            {
                Dateiname = Path.GetFileName(dateiPfad),
                Pfad = dateiPfad
            };

            if (dateiPfad.Contains(@"test1.dat"))
            {
                datei.Groesse = 26;
            }
            else if (dateiPfad.Contains(@"_xyz.dat"))
            {
                datei.Groesse = 10;
            }
            else
            {
                datei.Groesse = 10;
            }

            return datei;
        }

        public byte[] LeseInhalt(string dateiPfad)
        {
            if (dateiPfad.Contains(@"test1.dat"))
            {
                return Encoding.UTF8.GetBytes("abcdefghijklmnopqrstuvwxyz");
            }
            else if (dateiPfad.Contains(@"_xyz.dat"))
            {
                return Encoding.UTF8.GetBytes("0123456789");
            }
            else
            {
                return Encoding.UTF8.GetBytes("9876543210");
            }
        }
    }
}