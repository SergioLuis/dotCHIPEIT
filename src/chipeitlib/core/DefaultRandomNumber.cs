using System;

using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    /// <summary>
    /// Default implementation for the IRandomNumber interface.
    /// </summary>
    public class DefaultRandomNumber : IRandomNumber
    {
        int IRandomNumber.NextInt(int minimum, int maximum)
        {
            return mRandom.Next(minimum, maximum + 1);
        }

        readonly Random mRandom = new Random(Environment.TickCount);
    }
}
