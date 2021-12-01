using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DuplicateFilesFinder
{
    class Dublette : IDublette
    {
        
        public IEnumerable<string> Dateipfade { get; }

        public Dublette(IEnumerable<string> dateipfade)
        {
            this.Dateipfade = dateipfade;
        }
        
    }
}
