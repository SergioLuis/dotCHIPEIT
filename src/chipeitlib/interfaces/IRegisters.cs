namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents Chip-8 VM registers.
    /// </summary>
    public interface IRegisters
    {
        /// <summary>
        /// 'I' flag register.
        /// </summary>
        int I { get; set; }

        /// <summary>
        /// Program Counter.
        /// </summary>
        int PC { get; set; }

        /// <summary>
        /// Stack Pointer.
        /// </summary>
        int SP { get; set; }

        /// <summary>
        /// Reads from, and writes to, the specified <see cref="RegIds"/>
        /// register.
        /// </summary>
        /// <param name="reg">Id of the register to access.</param>
        /// <returns></returns>
        byte this[RegIds reg] { get; set; }
    }
}
