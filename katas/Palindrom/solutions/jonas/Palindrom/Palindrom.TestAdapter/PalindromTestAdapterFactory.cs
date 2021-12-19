using Palindrom.Abstractions;
using Palindrom.FirstImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Palindrom.TestAdapter
{
    public static class PalindromTestAdapterFactory
    {
        public static IPalindromTestAdapterObject Create()
        {
            return new PalindromTestAdapterObject
            {
                WrappedObject = new PalindromFirstImplementation()
            };
        }
        
    }
}
