using System;
using System.Collections.Generic;
using System.Linq;

using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    /// <summary>
    /// Clock frequency divider that uses a <see cref="IClock"/> as a time
    /// reference. Refer to the documentation of <see cref="IClockDivider"/>
    /// for further information.
    /// </summary>
    public class ClockDivider : IClockDivider
    {
        long IClockDivider.MsPerStep
        {
            get => mMsPerStep;
            set
            {
                CheckValidMsPerStep(value, "value");
                mMsPerStep = value;
            }
        }

        event EventHandler IClockDivider.Step
        {
            add => mStepEventHandlers.Add(value);
            remove => mStepEventHandlers.Remove(value);
        }

        long IClockDivider.MsLeft => (mLastMs + mMsPerStep) - mClock.Ms;

        /// <summary>
        /// Creates a new <see cref="ClockDivider"/> instance.
        /// </summary>
        /// <param name="clock">
        /// Clock used to measure when this <see cref="ClockDivider"/> should
        /// trigger the next <see cref="IClockDivider.Step"/> event. It is
        /// recommended that you use a <see cref="Chronometer"/> as the clock,
        /// as it can be paused and resumed.
        /// </param>
        /// <param name="msPerStep">
        /// Milliseconds between each <see cref="IClockDivider.Step"/> event.
        /// </param>
        public ClockDivider(IClock clock, long msPerStep)
        {
            CheckValidMsPerStep(msPerStep, "msPerStep");
            mClock = clock;
            mMsPerStep = msPerStep;
            mObservers = new List<IClockDividerObserver>();
            mStepEventHandlers = new List<EventHandler>();

            mLastMs = clock.Ms;
            mThis = this;
        }

        IDisposable IClockDivider.AddObserver(IClockDividerObserver observer)
        {
            mThis.Step += observer.ClockDividerStep;
            mObservers.Add(observer);
            return new ClockDividerSubscription(this, observer);
        }

        internal void RemoveObserver(IClockDividerObserver observer)
        {
            IClockDividerObserver myObserver =
                mObservers.FirstOrDefault(o => ReferenceEquals(o, observer));

            if (myObserver == default(IClockDividerObserver))
                return;

            mThis.Step -= myObserver.ClockDividerStep;
            mObservers.Remove(myObserver);
        }

        void IClockDivider.Update()
        {
            if (mThis.MsLeft > 0)
                return;

            mStepEventHandlers.ForEach(e => e?.Invoke(this, EventArgs.Empty));

            mLastMs += mMsPerStep;
        }

        static void CheckValidMsPerStep(long value, string paramName)
        {
            if (value > 0)
                return;

            throw new ArgumentException(
                LibLocalization.Get().Localize(
                    LibLocalization.Keys.InvalidMsPerStepArgumentException,
                    value),
                paramName);
        }

        readonly IClock mClock;
        readonly List<IClockDividerObserver> mObservers;
        readonly List<EventHandler> mStepEventHandlers;

        readonly IClockDivider mThis;

        long mMsPerStep;
        long mLastMs;
    }
}
