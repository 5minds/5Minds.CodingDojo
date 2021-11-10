using NextBiggerNumber.FirstImplementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBiggerNumber.TestAdapter
{
    public static class NextBiggerNumberTestAdapterFactory
    {
        public static INextBiggerNumberTestAdapterObject CreateFirstImplementation()
        {
            return new NextBiggerNumberTestAdapterObject
            {
                WrappedObject = new NextBiggerNumberFirstImplementation()
            };
        }
    }
}
