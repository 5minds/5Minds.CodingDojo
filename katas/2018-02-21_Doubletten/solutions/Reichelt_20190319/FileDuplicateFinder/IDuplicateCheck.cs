using System.Collections.Generic;

namespace FileDuplicateFinder
{
    public interface IDuplicateCheck
    {
        // Finds file duplicate candidates only by file size (= default search mode)
        IEnumerable<IDuplicate> FindCandidates(string searchPath);

        // Finds file duplicate candidates by comparision mode
        IEnumerable<IDuplicate> FindCandidates(string searchPath, CompareModeEnum compareMode);

        // Check file duplicate candidates by using MD5 hash
        IEnumerable<IDuplicate> CheckCandidates(IEnumerable<IDuplicate> candidates);
    }
}
