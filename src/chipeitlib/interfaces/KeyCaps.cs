using System;

namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// Represents each of the Chip-8 VM keys. It is a flag enum because
    /// several keys can be pressed and released at the same time.
    /// </summary>
    [Flags]
    public enum KeyCaps
    {
        None = 0,
        Key_0 = 1 << 0,
        Key_1 = 1 << 2,
        Key_2 = 1 << 3,
        Key_3 = 1 << 4,
        Key_4 = 1 << 5,
        Key_5 = 1 << 6,
        Key_6 = 1 << 7,
        Key_7 = 1 << 8,
        Key_8 = 1 << 9,
        Key_9 = 1 << 10,
        Key_A = 1 << 11,
        Key_B = 1 << 12,
        Key_C = 1 << 13,
        Key_D = 1 << 14,
        Key_E = 1 << 15,
        Key_F = 1 << 16
    }
}
