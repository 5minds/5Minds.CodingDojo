using System.Collections.Generic;

using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Shared.Domain.Services
{
    /// <summary>
    /// Calculates the FizzBuzz data of a number and converts them to text. 
    /// </summary>
    public interface IFBService
    {
        /// <summary>
        /// Returns the FizzBuzz data of a number and converts them to text
        /// </summary>
        /// <param name="variation">The variation to be used to caculate the FizzBuzz data</param>
        /// <param name="max">A number to calculate the FizzBuzz data from 1 to that number</param>
        /// <returns>The FizzBuzz of the number</returns>
        IEnumerable<string> Get(EVariation variation, int max);
    }
}