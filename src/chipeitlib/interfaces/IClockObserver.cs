namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents an object that should do an action on every clock tick.
    /// On a CHIP-8 emulator, good candidates to be a <see cref="IClockObserver"/>
    /// are the CPU (which must execute an instruction on each clock tick), the
    /// sound timer (which must play a sound for a given number of clock ticks),
    /// and the delay timer (which holds a flag for a given number of clock
    /// ticks, and it is used to sync events).
    ///
    /// For funsies, the CPU clock and the timers' clocks work at different
    /// frequencies - hence the <see cref="IClockDivider"/> interface.
    /// </summary>
    public interface IClockObserver
    {
        /// <summary>
        /// Notifies this <see cref="IClockObserver"/> that the clock that
        /// synchronizes its actions ticked.
        /// </summary>
        void OnClockTick();
    }
}
