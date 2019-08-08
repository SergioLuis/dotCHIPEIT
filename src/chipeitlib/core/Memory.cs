using System;

using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    /// <summary>
    /// Represents a contiguous memory of type <see cref="T"/>.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public struct Memory<T> : IMemory<T>
    {
        T IMemory<T>.this[int address]
        {
            get => mContent[address];
            set => mContent[address] = value;
        }

        int IMemory<T>.Size => mContent.Length;

        /// <summary>
        /// Creates an empty memory of a determinate size.
        /// </summary>
        /// <param name="size">Size of the new empty memory.</param>
        public Memory(ulong size)
        {
            mContent = new T[size];
        }

        /// <summary>
        /// Creates a new memory from the content of an array. The size of the
        /// memory will be the same as the <paramref name="content"/> it is
        /// initialized with.
        /// </summary>
        /// <param name="content">Initial content of the memory.</param>
        public Memory(T[] content)
        {
            mContent = new T[content.Length];
            Array.Copy(content, 0, mContent, 0, mContent.Length);
        }

        readonly T[] mContent;
    }
}
