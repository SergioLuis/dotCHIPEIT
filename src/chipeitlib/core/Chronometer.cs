using System;

using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    /// <summary>
    /// Keeps track of how much time has passed using a <see cref="IClock"/> as
    /// the reference.
    /// </summary>
    public class Chronometer : IChronometer
    {
        /// <summary>
        /// Creates a new <see cref="Chronometer"/> instance.
        /// </summary>
        /// <param name="clock">
        /// The <see cref="IClock"/> used as a reference for time measurement.
        /// </param>
        public Chronometer(IClock clock)
        {
            mClock = clock;
        }

        bool IChronometer.IsRunning => mbIsRunning;

        long IClock.Ms => mClockMillis - mIdleTime;

        void IChronometer.Start()
        {
            lock (mSyncLock)
            {
                if (mbIsRunning)
                    return;

                mClock.Update();
                mIdleTime += mClock.Ms - mLastStop;
                mbIsRunning = true; 
            }
        }

        void IChronometer.Stop()
        {
            lock (mSyncLock)
            {
                if (!mbIsRunning)
                    return;

                mbIsRunning = false;
                mLastStop = mClock.Ms;
            }
        }

        IClock IClock.Update()
        {
            lock (mSyncLock)
            {
                if (!mbIsRunning)
                {
                    throw new InvalidOperationException(
                        LibLocalization.Get().Localize(
                            LibLocalization.Keys.ChronometerNotRunningException));
                }

                mClockMillis = mClock.Update().Ms;
                return this;
            }
        }

        readonly IClock mClock;
        readonly object mSyncLock;

        long mIdleTime;
        long mLastStop;
        long mClockMillis;

        bool mbIsRunning;
    }
}
