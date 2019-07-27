using System;

namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents a clock frequency divider. It implements the observer pattern
    /// to trigger a clock tick on each of its observers.
    /// </summary>
    public interface IClockDivider
    {
        /// <summary>
        /// The number of milliseconds per step of this clock divider.
        /// This means that every n <see cref="MsPerStep"/>, the <see cref="IClockDivider"/>
        /// instance will trigger a step on its <see cref="IClockDividerObserver"/>.
        /// </summary>
        long MsPerStep { get; set; }

        /// <summary>
        /// Milliseconds left until the next time this <see cref="IClockDivider"/>
        /// will trigger. Will always be equal to or less than <see cref="MsPerStep"/>.
        /// It can even be negative if the last trigger time was missed.
        /// </summary>
        long MsLeft { get; }

        /// <summary>
        /// Event triggered when this <see cref="IClockDivider"/> finishes a
        /// step.
        /// </summary>
        event EventHandler Step;

        /// <summary>
        /// Adds a <see cref="IClockDividerObserver"/> to be notified on each step.
        /// </summary>
        /// <param name="observer">
        /// The <see cref="IClockDividerObserver"/> to be added as an observer.
        /// </param>
        /// <returns>
        /// A <see cref="IDisposable"/> representing the subscription.
        /// </returns>
        IDisposable AddObserver(IClockDividerObserver observer);

        /// <summary>
        /// Updates the internal measure of time of this <see cref="IClockDivider"/>.
        /// After the update, if <see cref="MsLeft"/> is less than or
        /// equal to zero, this <see cref="IClockDivider"/> will trigger event
        /// <see cref="IClockDividerObserver.ClockDividerStep"/> on each one of
        /// its observers.
        /// </summary>
        void Update();
    }
}
