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

        /// <summary>
        /// Adds a <see cref="ITimerObserver"/> to be notified when the timer
        /// reachs zero (<code>disabled</code>) and when it becomes different
        /// than zero (<code>enabled</code>).
        /// </summary>
        /// <param name="observer"></param>
        /// <returns></returns>
        IDisposable AddObserver(ITimerObserver observer);
    }

    /// <summary>
    /// Arguments to the event that <see cref="ITimer"/> emits to
    /// <see cref="ITimerObserver"/> when the enablement state of the Timer
    /// changes.
    /// </summary>
    public class TimerEventArgs : EventArgs
    {
        /// <summary>
        /// Whether or not the <see cref="ITimer"/> is <code>enabled</code>
        /// (it's value is different from zero) or <code>disabled</code> (it's
        /// value is zero).
        /// </summary>
        public bool Enabled { get; private set; }

        /// <summary>
        /// Builds a <see cref="TimerEventArgs"/> from the enablement status
        /// of the <see cref="ITimer"/>.
        /// </summary>
        /// <param name="enabledState"></param>
        public TimerEventArgs(bool enabledState)
        {
            Enabled = enabledState;
        }
    }
}
