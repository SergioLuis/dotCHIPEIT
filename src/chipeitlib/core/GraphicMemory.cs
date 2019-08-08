using System;
using System.Collections.Generic;

using Chipeit.Lib.Extensions;
using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    public class GraphicMemory : IGraphicMemory<bool>
    {
        Size IGraphicMemory<bool>.DisplaySize => mDisplaySize;

        event EventHandler IGraphicMemory<bool>.Dirty
        {
            add => mDirtyEventHandlers.Add(value);
            remove => mDirtyEventHandlers.Remove(value);
        }

        public GraphicMemory(Size displaySize, IMemory<bool> baseMemory)
        {
            CheckMemorySize(displaySize, baseMemory);

            mDirtyEventHandlers = new List<EventHandler>();
            mBaseMemory = baseMemory;
            mDisplaySize = displaySize;
        }

        void IGraphicMemory<bool>.Clear() => mBaseMemory.Fill(false);

        bool IGraphicMemory<bool>.Get(int x, int y) =>
            mBaseMemory[FlattenCartesianCoordinates(mDisplaySize, x, y)];

        bool IGraphicMemory<bool>.XorRow(int x, int y, byte spriteRow)
        {
            bool pixelCleared = false;
            for (int i = 0; i < 8; i++)
            {
                int memoryIdx = FlattenCartesianCoordinates(mDisplaySize, x + i, y);

                bool previousState = mBaseMemory[memoryIdx];
                bool newState = previousState ^ (spriteRow >> (7 - i) & 0x01) == 0x01;
                mBaseMemory[memoryIdx] = newState;

                pixelCleared = pixelCleared || (previousState && !newState);
            }

            foreach (EventHandler handler in mDirtyEventHandlers)
                handler?.Invoke(this, EventArgs.Empty);

            return pixelCleared;
        }

        static int FlattenCartesianCoordinates(Size size, int x, int y)
        {
            // http://devernay.free.fr/hacks/chip8/C8TECH10.HTM#Dxyn
            // If the sprite is positioned so part of it is outside the
            // coordinates of the display, it wraps around to the opposite
            // side of the screen.
            // So, we'll suppose wrapping on both columns and rows.
            x %= size.Width;
            y %= size.Height;

            return y * size.Width + x;
        }

        static void CheckMemorySize(Size size, IMemory<bool> memory)
        {
            int pixels = size.Width * size.Height;
            if (memory.Size == pixels)
                return;

            throw new ArgumentOutOfRangeException(
                "baseMemory",
                LibLocalization.Get().Localize(
                    LibLocalization.Keys.InvalidGraphicMemorySize,
                    size.Width,
                    size.Height,
                    pixels));
        }

        readonly List<EventHandler> mDirtyEventHandlers;
        readonly IMemory<bool> mBaseMemory;
        readonly Size mDisplaySize;
    }
}
