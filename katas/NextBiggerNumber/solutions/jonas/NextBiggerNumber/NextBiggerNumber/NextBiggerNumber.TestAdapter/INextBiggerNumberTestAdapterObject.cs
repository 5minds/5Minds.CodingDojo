using NextBiggerNumber.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBiggerNumber.TestAdapter
{
    public interface INextBiggerNumberTestAdapterObject
    {
        INextBiggerNumber WrappedObject { get; set; }

        int NextBigger(int number);
    }
}
