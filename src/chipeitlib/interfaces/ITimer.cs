using System;

namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents a timer. In Chip-8, a timer counts down from a specified
    /// number, decreasing said number each clock tick.
    /// </summary>
    public interface ITimer : IClockDividerObserver
    {
        /// <summary>
        /// Ticks left in the countdown.
        /// </summary>
        byte TicksLeft { get; set; }

        /// <summary>
        /// Indicates wether or not this <see cref="ITimer"/> is active.
        /// An active timer has one or more <see cref="TicksLeft"/>.
        /// </summary>
        bool IsActive { get; }
    }
}
