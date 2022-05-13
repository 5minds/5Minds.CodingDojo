using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using FindDuplicates.Enums;
using FindDuplicates.Interfaces;
using FindDuplicates.Models;

namespace FindDuplicates
{
    public class Dublettenprüfung : IDublettenprüfung
    {
        #region Public Methods
        public IEnumerable<IDublette> Sammle_Kandidaten(string pfad)
        {
            return Sammle_Kandidaten(pfad, Vergleichsmodi.Größe);
        }

        public IEnumerable<IDublette> Sammle_Kandidaten(string pfad, Vergleichsmodi modus)
        {
            if (!Directory.Exists(pfad))
            {
                throw new ArgumentException("Path does not Exits");
            }

            var fileInfos = GetAllFilesFromDirectory(pfad);

            return modus == Vergleichsmodi.Größe ? CheckFileSize(fileInfos) : CheckFileSizeAndName(fileInfos);
        }

        public IEnumerable<IDublette> Prüfe_Kandidaten(IEnumerable<IDublette> kandidaten)
        {
            if (!kandidaten.Any())
            {
                throw new ArgumentException();
            }

            var dublettenDict = CreateDublettenDictionary(kandidaten);

            return CompareHashes(dublettenDict);
        }
        #endregion

        #region Private Methods

        private IEnumerable<IDublette> CompareHashes(Dictionary<FileInfo, string> dublettenDict)
        {
            return dublettenDict.GroupBy(x => x.Value).Where(x => x.Count() > 1).Select(
                x => new Dublette(new List<string>(x.Select(s => s.Key.FullName)))
               
            );
        }

        private Dictionary<FileInfo, string> CreateDublettenDictionary(IEnumerable<IDublette> kandidaten)
        {
            var dublettenDict = new Dictionary<FileInfo, string>();

            foreach (var duplicateCandidate in kandidaten)
            {
                foreach (var Dateipfade in duplicateCandidate.Dateipfade)
                {
                    dublettenDict.Add(new FileInfo(Dateipfade), CreateMd5FromFile(Dateipfade));
                }
            }

            return dublettenDict;
        }

        private string CreateMd5FromFile(string pfad)
        {
            using (var md5 = MD5.Create())
            {
                using (var stream = File.OpenRead(pfad))
                {
                    var hash = md5.ComputeHash(stream);
                    return BitConverter.ToString(hash).Replace("-", "").ToLowerInvariant();
                }
            }
        }
        
        private List<IDublette> CheckFileSize(List<FileInfo> fileInfos)
        {
            var result = new List<IDublette>();

            var checkedFileInfos = fileInfos.GroupBy(x => x.Length).Where(x => x.Count() > 1);

            foreach (var checkedFileInfo in checkedFileInfos)
            {
                result.Add(new Dublette(new List<string>(checkedFileInfo.Select(x => x.FullName))));
            }

            return result;
        }

        private List<IDublette> CheckFileSizeAndName(List<FileInfo> fileInfos)
        {
            var result = new List<IDublette>();

            var checkedFileInfos = fileInfos.GroupBy(x => new { x.Length, x.Name }).Where(x => x.Count() > 1);

            foreach (var checkedFileInfo in checkedFileInfos)
            {
                result.Add(new Dublette(new List<string>(checkedFileInfo.Select(x => x.FullName))));
            }

            return result;
        }
        
        private List<FileInfo> GetAllFilesFromDirectory(string pfad)
        {
            var filePathList = Directory.GetFiles(pfad, "*", SearchOption.AllDirectories).ToList();

            return filePathList.Select(filePath => new FileInfo(filePath)).ToList();
        }

        #endregion
    }
}