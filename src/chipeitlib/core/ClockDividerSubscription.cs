﻿using System;

using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    internal class ClockDividerSubscription : IDisposable
    {
        internal ClockDividerSubscription(
            ClockDivider divider, IClockDividerObserver observer)
        {
            mDivider = divider;
            mObserver = observer;
        }

        #region IDisposable Support
        protected virtual void Dispose(bool disposing)
        {
            if (mbAlreadyDisposed)
                return;

            if (disposing)
                mDivider.RemoveObserver(mObserver);

            mbAlreadyDisposed = true;
        }

        void IDisposable.Dispose()
        {
            Dispose(true);
        }

        bool mbAlreadyDisposed = false;
        #endregion

        readonly ClockDivider mDivider;
        readonly IClockDividerObserver mObserver;
    }
}
