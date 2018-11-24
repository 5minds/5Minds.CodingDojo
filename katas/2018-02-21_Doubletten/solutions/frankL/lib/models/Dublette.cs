using System.Collections.Generic;
using common.interfaces;
using System.Linq;

namespace lib.models
{
    public class Dublette : IDublette
    {
        public Dublette()
        {
            Dateipfade = new List<string>();
        }

        public ICollection<string> Dateipfade { get; private set; }
    }
}