namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents an object that observes changes in a <see cref="ITimer"/>,
    /// which can be <code>enabled</code> or <code>disabled</code>, but not
    /// both nor neither at any given time.
    /// In a Chip-8 emulator, the perfect candidate to be a <see cref="ITimerObserver"/>
    /// is a physical speaker or beeper that must emit sound when <code>enabled</code>,
    /// and be quiet when <code>disabled</code>.
    /// </summary>
    public interface ITimerObserver
    {
        /// <summary>
        /// Event handler triggered when the <see cref="ITimer"/> this
        /// <see cref="ITimerObserver"/> instance is subscribed to changes.
        /// </summary>
        /// <param name="sender">
        /// The <see cref="ITimer"/> that triggered this event.
        /// </param>
        /// <param name="e">Arguments of the event</param>
        void EnablementStatusChange(object sender, TimerEventArgs e);
    }
}
