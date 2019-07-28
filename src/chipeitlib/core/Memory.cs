using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    public struct Memory<T> : IMemory<T>
    {
        T IMemory<T>.this[int address]
        {
            get => mContent[address];
            set => mContent[address] = value;
        }

        int IMemory<T>.Size => mContent.Length;

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
