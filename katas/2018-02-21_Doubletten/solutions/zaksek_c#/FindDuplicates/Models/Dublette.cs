using System.Collections.Generic;
using FindDuplicates.Interfaces;

namespace FindDuplicates.Models
{
    public class Dublette : IDublette
    {
        public IEnumerable<string> Dateipfade { get; }

        public Dublette(IEnumerable<string> dateipfade)
        {
            Dateipfade = dateipfade;
        }
    }
}