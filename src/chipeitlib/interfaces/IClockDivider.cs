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
        /// This means that every n <see cref="MillisPerStep"/>, the <see cref="IClockDivider"/>
        /// instance will trigger a step on its <see cref="IClockObserver"/>.
        /// </summary>
        long MillisPerStep { get; set; }

        /// <summary>
        /// Milliseconds left until the next time this <see cref="IClockDivider"/>
        /// will trigger. Will always be equal to or less than <see cref="MillisPerStep"/>.
        /// It can even be negative if the last trigger time was missed.
        /// </summary>
        long MillisLeft { get; }

        /// <summary>
        /// Adds a <see cref="IClockObserver"/> to be notified on each step.
        /// </summary>
        /// <param name="observer">
        /// The <see cref="IClockObserver"/> to be added as an observer.
        /// </param>
        /// <returns>
        /// A <see cref="IDisposable"/> representing the subscription.
        /// </returns>
        IDisposable AddObserver(IClockObserver observer);

        /// <summary>
        /// Updates the internal measure of time of this <see cref="IClockDivider"/>.
        /// After the update, if <see cref="MillisLeft"/> is less than or
        /// equal to zero, this <see cref="IClockDivider"/> will call to
        /// <see cref="IClockObserver.OnClockTick"/> on each one of its observers.
        /// </summary>
        void TriggerUpdate();
    }
}
