namespace Chipeit.Lib.Interfaces.IO
{
    /// <summary>
    /// Represents the memory that holds what must be printed on the screen.
    /// The screen is a matrix of <see cref="Width"/> pixels wide, and
    /// <see cref="Height"/> pixes tall, in which each pixel can either be
    /// colored or not.
    /// </summary>
    public interface IGraphicMemory
    {
        /// <summary>
        /// Number of pixes of width (<code>x</code> coordinate).
        /// </summary>
        int Width { get; }

        /// <summary>
        /// Number of pixes of height (<code>y</code> coordinate).
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Whether or not the pixel in <code><x, y></code> is colored.
        /// 
        /// <para
        /// </summary>
        /// <param name="x">
        /// <code>x</code> coordinate. Must be in range [0, <see cref="Width"/> - 1].
        /// </param>
        /// <param name="y">
        /// <code>y</code> coordinate. Must be in range [0, <see cref="Height"/> - 1].
        /// </param>
        /// <returns>
        /// <code>true</code> if the pixel is colored, <code>false</code> otherwise.
        /// </returns>.
        bool Colored(int x, int y);
    }
}
