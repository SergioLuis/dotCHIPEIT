using System;

namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents the keyboard the Chip-8 has access to, along with the
    /// necessary operations to handle it.
    /// </summary>
    public interface IKeyboard
    {
        /// <summary>
        /// The sound timer used by this keyboard.
        /// </summary>
        ITimer SoundTimer { get; }

        /// <summary>
        /// Indicates wether or not this <see cref="IKeyboard"/> is capturing
        /// the next key release. See <see cref="CapturedKeyRelease"/> and
        /// <see cref="CaptureNextKeyRelease"/> for further information.
        /// </summary>
        bool IsCapturingNextKeyRelease { get; }

        /// <summary>
        /// The key release captured after the last time the <see cref="CaptureNextKeyRelease"/>
        /// function was called on this object.
        /// </summary>
        KeyCaps CapturedKeyRelease { get; }

        /// <summary>
        /// Sets the keyboard to capture the next key that is released. Once
        /// the first key is released, the <see cref="CapturedKeyRelease"/>
        /// holds the captured value, 
        /// </summary>
        void CaptureNextKeyRelease();

        /// <summary>
        /// Clears the value of <see cref="CapturedKeyRelease"/>.
        /// </summary>
        void ClearLastCapturedKeyRelease();

        /// <summary>
        /// Updates the <see cref="SoundTimer"/> to keep playing a sound if
        /// necessary.
        /// </summary>
        void UpdateSoundTimerCounter();

        /// <summary>
        /// Whether or not the specified keys are in pressed state.
        /// </summary>
        /// <param name="keys"></param>
        /// <returns></returns>
        bool IsPressed(KeyCaps keys);
    }
}
