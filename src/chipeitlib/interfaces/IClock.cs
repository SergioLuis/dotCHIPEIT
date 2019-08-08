using System;

namespace Chipeit.Lib.Interfaces
{
    /// <summary>
    /// What is a clock? If your answer is "something to measure how time
    /// passes", you would be wrong.
    /// A <see cref="IClock"/> gives the system a framework for understanding
    /// what _is_ time.
    /// A <see cref="IChronometer"/> is the tool within that framework that
    /// actually _keeps track_ of how much time has passed.
    /// </summary>
    public interface IClock
    {
        /// <summary>
        /// Current system time, in Milliseconds.
        /// It will hold the same value until it is updated through the <see cref="Update"/>
        /// method. This way, the emulator can hold the same time frame for
        /// several operations that in actual hardware should happen at the
        /// same time, but that in an emulator they might not.
        /// </summary>
        /// <remarks>
        /// Please note that naming this property "Milliseconds" is just for
        /// convenience. Milliseconds are a well-known measure unit for every
        /// human being, but this property might not actually represent
        /// milliseconds in the same way humans _perceive_ them.
        /// Implementations of this class might account for milliseconds way
        /// slower or faster than your average wrist clock.
        /// However, even if you encounter such inaccuracies, you should treat
        /// this property as actual, real-world milliseconds (specially when
        /// converting them back and forth between other units, such as hertz).
        /// </remarks>
        long Ms { get; }

        /// <summary>
        /// Updates the current time frame represented by <see cref="Ms"/>.
        /// </summary>
        /// <returns>
        /// A reference to this <see cref="IClock"/> object, for method chaining
        /// if necessary.
        /// </returns>
        /// <remarks>
        /// After calling this method, reading the <see cref="Ms"/> property
        /// must return a value equal to, or greater than it was before calling
        /// this method.
        /// Doc Brown knew how to travel back in time - this emulator might not
        /// (or at least, it could suffer less entertaining consequences than
        /// Marty McFly).
        /// </remarks>
        IClock Update();
    }
}
