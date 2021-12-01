using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFilesFinder.Model
{
    public class FilesInfo
    {
        public List<Files> Files { get; set; }
    }
    public class Files
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
        public string FileSize { get; set; }       
    }
}
