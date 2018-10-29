namespace Doublette.Implementations
{
    using System;
    using System.Collections.Generic;

    using Doublette.Contracts;

    public class Dublette : IDublette
    {
        private ICollection<string> pfade;

        public Dublette()
        {
            pfade = new List<string>();
        }
        public ICollection<string> Dateipfade 
        { 
            get
            {
                return pfade;
            }

            private set
            {
                pfade = value as ICollection<string>;
            }
        }
    }
}