using System.Collections.Generic;

namespace FileDuplicateFinder
{
    public interface IDuplicate
    {
        IEnumerable<string> FilePaths { get; }
    }
}
