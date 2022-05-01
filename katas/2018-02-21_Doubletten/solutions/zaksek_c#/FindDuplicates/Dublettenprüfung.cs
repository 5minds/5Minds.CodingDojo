using System.Collections.Generic;
using System.IO;
using System.Linq;
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
                throw new System.ArgumentException("Path does not Exits");
            }

            var fileInfos = GetAllFilesFromDirectory(pfad);

            return modus == Vergleichsmodi.Größe ? CheckFileSize(fileInfos) : CheckFileSizeAndName(fileInfos);
        }

        public IEnumerable<IDublette> Prüfe_Kandidaten(IEnumerable<IDublette> kandidaten)
        {
            throw new System.NotImplementedException();
        }
        #endregion

        #region Private Methods
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