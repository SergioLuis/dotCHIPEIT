using System;

namespace Chipeit.Lib.Extensions
{
    /// <summary>
    /// Extensions methods for the <see cref="DateTime"/> struct.
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// Extracts the total ceiled amount of milliseconds from a <see cref="DateTime"/>
        /// </summary>
        /// <param name="dateTime">
        /// The <see cref="DateTime"/> from which to extract the milliseconds.
        /// </param>
        /// <returns>
        /// The total ceiled amount of milliseconds in the <paramref name="dateTime"/>
        /// struct.
        /// </returns>
        public static long TotalMillis(this DateTime dateTime)
        {
            return (long)Math.Ceiling(TimeSpan.FromTicks(dateTime.Ticks).TotalMilliseconds);
        }
    }
}
