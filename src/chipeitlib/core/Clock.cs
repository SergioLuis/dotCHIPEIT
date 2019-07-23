using System;

using Chipeit.Lib.Extensions;
using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    public class Clock : IClock
    {
        long IClock.Millis => mMillis;

        IClock IClock.Update()
        {
            mMillis = DateTime.UtcNow.TotalMillis();
            return this;
        }

        long mMillis;
    }
}
