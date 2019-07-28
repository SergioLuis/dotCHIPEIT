namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents a R/W memory of type <see cref="T"/> accessible by address.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IMemory<T>
    {
        /// <summary>
        /// Size of the memory.
        /// </summary>
        ulong Size { get; }

        /// <summary>
        /// Reads from, or writes to this <see cref="IMemory{T}"/> at the
        /// specified address.
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        T this[ulong address] { get; set; }
    }
}
