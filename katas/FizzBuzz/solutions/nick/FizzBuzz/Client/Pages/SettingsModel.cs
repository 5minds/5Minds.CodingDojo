using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using DataAnnotationsExtensions;

namespace FizzBuzz.Client.Pages
{
    /// <summary>
    /// Keeps the settings required to consume the api.
    /// </summary>
    public class SettingsModel
    {
        [Min(0)]
        [Max(1)]
        public int VariationNumber { get; set; }

        [Min(10)]
        [Max(100)]
        public int Max { get; set; }
    }
}
