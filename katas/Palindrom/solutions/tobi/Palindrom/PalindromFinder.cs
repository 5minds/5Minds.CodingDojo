using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom
{
    public interface IPalindromFinder
    {
        bool IsPalindrom(string text);
    }

    public class PalindromFinder : IPalindromFinder
    {
        public bool IsPalindrom(string text)
        {
            throw new NotImplementedException();
        }
    }
}
