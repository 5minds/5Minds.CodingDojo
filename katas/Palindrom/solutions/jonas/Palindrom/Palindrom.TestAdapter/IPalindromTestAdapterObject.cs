using Palindrom.Abstractions;
using System;

namespace Palindrom.TestAdapter
{
    public interface IPalindromTestAdapterObject
    {
        IPalindrom WrappedObject { get; set; }

        bool IsPalindrom(string inputString);
    }
}
