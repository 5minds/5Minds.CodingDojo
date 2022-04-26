using FizzBuzz.Shared.Domain.Model.Enums;

namespace FizzBuzz.Server.Providers
{
    /// <summary>
    /// Keeps the variation of a FBCalculator and determines if it can handle 
    /// a given variation or not.
    /// </summary>
    public abstract class BaseFBCalculator
    {
        /// <summary>
        /// The variation accepted by a this FBCalculator.
        /// </summary>
        public EVariation Variation { get; set; }

        /// <summary>
        /// Whether this FBCalculator can handle the given variation or not.
        /// </summary>
        /// <param name="variation">Given variation to be handled</param>
        /// <returns>Returns a boolean indicationg that this FBCalculator can handle the given variation or not.</returns>
        public bool CanHandle(EVariation variation) => variation == Variation;
    }
}