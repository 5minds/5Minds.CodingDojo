using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom
{
    public interface IPalindromChecker
    {
        bool IsPalindrom(string text);
    }

    public class PalindromChecker : IPalindromChecker
    {
        public bool IsPalindrom(string text)
        {
            throw new NotImplementedException();
        }
    }
}
