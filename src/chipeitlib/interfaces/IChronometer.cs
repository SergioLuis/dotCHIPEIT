using System;

namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Keeps track of how much time has passed for the whole time it has been
    /// running.
    /// </summary>
    public interface IChronometer : IClock
    {
        /// <summary>
        /// Flag indicating wether or not this <see cref="IChronometer"/> is
        /// running.
        /// The <see cref="IChronometer"/> is started using the <see cref="Start"/>
        /// method, and this flag will be <code>true</code>.
        /// The <see cref="IChronometer"/> is stopped using the <see cref="Stop"/>
        /// method, and this flag will be <code>false</code>.
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        /// Starts the chronometer. While the chronometer is running, it will
        /// update its <see cref="IClock.Ms"/> property. While the
        /// <see cref="IChronometer"/> instance is started, the <see cref="IsRunning"/>
        /// property will be <code>true</code>
        /// </summary>
        void Start();

        /// <summary>
        /// Stops the chronometer. While the chronometer is stopped, it will
        /// not update its <see cref="IClock.Ms"/> property. While the
        /// <see cref="IChronometer"/> instance is stopped, the <see cref="IsRunning"/>
        /// property will be <code>false</code>.
        /// </summary>
        void Stop();
    }
}
