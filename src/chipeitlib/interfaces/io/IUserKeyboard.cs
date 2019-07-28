namespace Chipeit.Lib.Interfaces.IO
{
    /// <summary>
    /// Represents the keyboard the user has access to, along with the two
    /// possible actions: pressing and releasing keys.
    /// </summary>
    public interface IUserKeyboard
    {
        /// <summary>
        /// Presses zero or more keys.
        /// <param name="keys">The keys being pressed.</param>
        void Press(KeyCaps keys);

        /// <summary>
        /// Releases zero or more keys.
        /// </summary>
        /// <param name="keys">The keys being released.</param>
        void Release(KeyCaps keys);
    }
}
