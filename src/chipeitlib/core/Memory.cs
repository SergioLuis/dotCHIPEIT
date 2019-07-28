using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    public struct Memory<T> : IMemory<T>
    {
        T IMemory<T>.this[ulong address]
        {
            get => mContent[address];
            set => mContent[address] = value;
        }

        ulong IMemory<T>.Size => (ulong)mContent.LongLength;

        public Memory(ulong size)
        {
            mContent = new T[size];
        }

        public Memory(T[] content)
        {
            mContent = content;
        }

        readonly T[] mContent;
    }
}
