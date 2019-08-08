namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents a random number generator.
    /// </summary>
    public interface IRandomNumber
    {
        /// <summary>
        /// Returns a random integer in the range [minimum, maximum].
        /// </summary>
        /// <param name="minimum">Lower bound for the next random integer.</param>
        /// <param name="maximum">Upper bound for the next random integer.</param>
        /// <returns></returns>
        int NextInt(int minimum, int maximum);
    }
}
