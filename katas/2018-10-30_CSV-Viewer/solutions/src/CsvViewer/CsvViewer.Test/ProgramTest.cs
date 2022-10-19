
using System;
using Xunit;

using CsvViewer;

namespace CsvViewer.Test
{
    public class ProgramTest
    {
        [Fact]
        public void ParseArguments_EmptyArray_Exception()
        {
            Assert.Throws<ArgumentException>(() => CsvViewer.Program.ParseArguments(new string[] { }));
        }
    }
}
