using NextBiggerNumber.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NextBiggerNumber.TestAdapter
{
    public class NextBiggerNumberTestAdapterObject : INextBiggerNumberTestAdapterObject
    {
        private INextBiggerNumber _wrappedObject;
        public INextBiggerNumber WrappedObject 
        { 
            get => _wrappedObject; 
            set => _wrappedObject = value; 
        }

        public int NextBigger(int number)
        {
            return _wrappedObject.NextBigger(number);
        }
    }
}
