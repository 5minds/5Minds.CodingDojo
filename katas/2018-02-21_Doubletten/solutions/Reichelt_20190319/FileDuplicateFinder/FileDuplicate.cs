using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace FileDuplicateFinder
{
    public class FileDuplicate : IDuplicate
    {
        // The list of duplicate files (FileInfo)
        public List<FileInfo> Files { get; set; }

        // The list of full paths for all duplicate files
        public IEnumerable<string> FilePaths
        {
            get
            {
                return Files.Select(file => file.FullName).ToList();
            }
        }
    }
}
