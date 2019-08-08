using System;

namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents the graphic memory of a Chip-8 emulator. This is, the matrix
    /// of pixels that will be painted on the screen.
    /// </summary>
    public interface IGraphicMemory
    {
        /// <summary>
        /// Event triggered when this <see cref="IGraphicMemory"/> is dirty
        /// (this is, it changed).
        /// You might want to redraw it whenever is dirty, or do so at regular
        /// intervals.
        /// </summary>
        event EventHandler Dirty;

        /// <summary>
        /// Represents the size (width and height) of the screen that this
        /// <see cref="IGraphicMemory"/> can be painted on.
        /// </summary>
        Size DisplaySize { get; }

        /// <summary>
        /// Accesses the pixel in a given column (x) and row (y).
        /// </summary>
        /// <param name="col">Column of the pixel to access.</param>
        /// <param name="row">Row of the pixel to access.</param>
        /// <returns></returns>
        bool Get(int col, int row);

        /// <summary>
        /// Draws a row of pixels (up to 8) starting in a given position.
        /// The row will be drawn on pixels
        ///     [(col, row), (col + 1, row) ... (col + 7, row)]
        /// In a Chip-8 emulator, rows are drawn doing a XOR of the current
        /// pixels and the new ones.
        /// </summary>
        /// <param name="col">Column of the initial pixel to draw the row.</param>
        /// <param name="row">Row of the initial pixel to draw the row.</param>
        /// <param name="rowToDraw">Row of pixels to draw starting at (col, row)</param>
        /// <returns>
        /// <code>true</code> if drawing <paramref name="rowToDraw"/> cleared
        /// any pixel on the screen. <code>false</code> otherwise.</returns>
        bool XorRow(int col, int row, byte rowToDraw);

        /// <summary>
        /// Clears the screen, resetting every pixel back to their off state.
        /// </summary>
        void Clear();
    }

    /// <summary>
    /// Represent a Size in a 2-dimensional space.
    /// </summary>
    public struct Size
    {
        public int Width { get; }
        public int Height { get; }

        public Size(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public static readonly Size Zero = new Size(0, 0);
        public static readonly Size Invalid = new Size(-1, -1);
    }
}
