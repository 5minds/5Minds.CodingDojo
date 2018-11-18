using System.Collections.Generic;

namespace CsvViewer
{
    public interface IDisplayAdapter
    {
        void Display(IEnumerable<string> content);
    }
}
