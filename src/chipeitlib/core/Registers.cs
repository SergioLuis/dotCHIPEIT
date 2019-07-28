using System;

using Chipeit.Lib.Interfaces;

namespace Chipeit.Lib.Core
{
    /// <summary>
    /// Implementation of <see cref="IRegisters"/>.
    /// </summary>
    public class Registers : IRegisters
    {
        int IRegisters.I { get; set; }

        int IRegisters.PC { get; set; }

        int IRegisters.SP { get; set; }

        byte IRegisters.this[RegIds reg]
        {
            get => mRegistersMemory[(int)reg];
            set => mRegistersMemory[(int)reg] = value;
        }

        /// <summary>
        /// Builds a <see cref="Registers"/> instance using the specified
        /// <see cref="IMemory{T}"/> as the memory for the registers. It must
        /// be as big as registers are.
        /// </summary>
        /// <param name="registersMemory">
        /// The <see cref="IMemory{T}"/> of 
        /// <see cref="byte"/> that holds the registers values.
        /// </param>
        public Registers(IMemory<byte> registersMemory)
        {
            CheckValidMemorySize(registersMemory);
            mRegistersMemory = registersMemory;
        }

        static void CheckValidMemorySize(IMemory<byte> registersMemory)
        {
            int expectedSize = Enum.GetValues(typeof(RegIds)).Length;
            int actualSize = registersMemory.Size;

            if (expectedSize == actualSize)
                return;

            throw new ArgumentException(
                LibLocalization.Get().Localize(
                    LibLocalization.Keys.InvalidRegistersMemorySize,
                    expectedSize, actualSize),
                "memory");
        }

        readonly IMemory<byte> mRegistersMemory;
    }
}
