namespace Doublette.Contracts
{
    using System.Collections.Generic;

    public interface IDublette
    {
        ICollection<string> Dateipfade { get; }    
    }
}