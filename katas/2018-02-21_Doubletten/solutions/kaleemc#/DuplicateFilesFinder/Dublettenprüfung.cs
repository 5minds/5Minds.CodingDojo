using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;
using DuplicateFilesFinder.Model;

namespace DuplicateFilesFinder
{
    class Dublettenprüfung : IDublettenprüfung
    {
        public IEnumerable<IDublette> Sammle_Kandidaten(string path)
        {
            return Sammle_Kandidaten(path, Vergleichsmodi.Größe);
        }
        public IEnumerable<IDublette> Sammle_Kandidaten(string pfad, Vergleichsmodi modus)
        {
            List<string> __duplicatefiles = new List<string>();
            List<Files> listofFiles = new List<Files>();

            if (Directory.Exists(pfad))
            {              
                Parallel.ForEach(Directory.EnumerateFiles(pfad, "*.*", SearchOption.AllDirectories), new ParallelOptions() { MaxDegreeOfParallelism = 5 }, thisFile =>
                {
                    Files result = new Files();
                    result.FileSize = new System.IO.FileInfo(thisFile).Length.ToString();
                    result.FileName = Path.GetFileName(thisFile);
                    result.FilePath = thisFile;
                    listofFiles.Add(result);
                });

                if (modus == Vergleichsmodi.Größe)
                {
                    var bySize = listofFiles.GroupBy(x => x.FileSize).Where(c => c.Count() > 1);                   
                    return bySize.Select(x => new Dublette(x.Select(fn => fn.FilePath)));
                }
                else
                {
                    var bySizeAndName = listofFiles.GroupBy(x => new { x.FileSize, x.FileName }).Where(y => y.Count() > 1);                   
                    return bySizeAndName.Select(x => new Dublette(x.Select(fn => fn.FilePath)));
                }

            }
            return null;
        }
        public IEnumerable<IDublette> Prüfe_Kandidaten(IEnumerable<IDublette> kandidaten)
        {
            List<IDublette> byHash = new List<IDublette>();
            foreach (var group in kandidaten)
            {
                var groups = group.Dateipfade
                    .GroupBy(fp => GetMD5(fp))
                    .Where(x => x.Count() > 1);
                byHash.AddRange(groups.Select(y => new Dublette(y)));
            }
            return byHash;
        }     

        private string GetMD5(string filename)
        {
            try
            {
                using (var md5 = MD5.Create())
                using (var stream = File.OpenRead(filename))
                {
                    byte[] hash = md5.ComputeHash(stream);
                    System.Console.WriteLine($"FileName: {filename}, HashValue: {BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant()} ");
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
