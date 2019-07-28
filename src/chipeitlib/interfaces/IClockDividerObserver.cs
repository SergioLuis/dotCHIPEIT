using System;

namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents an object that should do an action on every clock tick.
    /// On a CHIP-8 emulator, good candidates to be a <see cref="IClockDividerObserver"/>
    /// are the CPU (which must execute an instruction on each clock tick), the
    /// sound timer (which must play a sound for a given number of clock ticks),
    /// and the delay timer (which holds a flag for a given number of clock
    /// ticks, and it is used to sync events).
    ///
    /// For funsies, the CPU clock and the timers' clocks work at different
    /// frequencies - hence the <see cref="IClockDivider"/> interface.
    /// </summary>
    public interface IClockDividerObserver
    {
        /// <summary>
        /// Event handler triggered when the <see cref="IClockDivider"/> to 
        /// which this observer is subscribed triggers the <see cref="IClockDivider.Step"/>
        /// event.
        /// </summary>
        /// <paramref name="sender">Sender of the event.</paramref>
        /// <paramref name="e">Arguments of the event</paramref>
        void ClockDividerStep(object sender, EventArgs e);
    }
}
