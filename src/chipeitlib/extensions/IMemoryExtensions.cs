using System;

using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Extensions
{
    /// <summary>
    /// Extension methods for the <see cref="IMemory{T}"/> implementations.
    /// </summary>
    public static class IMemoryExtensions
    {
        /// <summary>
        /// Fills a <see cref="IMemory{T}"/> with a given value.
        /// </summary>
        /// <param name="memory">Memory to fill.</param>
        /// <param name="value">Value to fill the memory with.</param>
        public static void Fill<T>(this IMemory<T> memory, T value)
        {
            memory.ForEach((idx, _) => memory[idx] = value);
        }

        /// <summary>
        /// Executes an action for each one of the elements in the <see cref="IMemory{T}"/>.
        /// </summary>
        /// <param name="memory">
        /// Memory to loop exection the action.
        /// </param>
        /// <param name="indexAction">
        /// Action to execute. <see cref="int"/> param is the index, while
        /// <see cref="T"/> param is the value of the memory at said index.
        /// </param>
        public static void ForEach<T>(
            this IMemory<T> memory, Action<int, T> indexAction)
        {
            for (int i = 0; i < memory.Size; i++)
                indexAction(i, memory[i]);
        }
    }
}
