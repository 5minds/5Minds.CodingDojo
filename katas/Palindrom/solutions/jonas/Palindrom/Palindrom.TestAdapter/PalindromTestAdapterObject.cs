using Palindrom.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom.TestAdapter
{
    public class PalindromTestAdapterObject : IPalindromTestAdapterObject
    {
        private IPalindrom _wrappedObject;
        public IPalindrom WrappedObject
        {
            get => _wrappedObject;
            set => _wrappedObject = value;
        }

        public bool IsPalindrom(string inputString)
        {
            return _wrappedObject.IsPalindrom(inputString);
        }
    }
}
