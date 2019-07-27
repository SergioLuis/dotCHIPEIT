using System;

using Chipeit.Lib.Extensions;
using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    /// <summary>
    /// Acts as a time reference for the entire system, using the total ceiled
    /// milliseconds since DateTime.MinValue.
    /// </summary>
    public class Clock : IClock
    {
        long IClock.Ms => mMs;

        IClock IClock.Update()
        {
            mMs = DateTime.UtcNow.TotalMillis();
            return this;
        }

        long mMs;
    }
}
