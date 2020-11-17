using System;
using System.Collections.Generic;
using System.Text;

namespace Naamloos
{
    /// <summary>
    /// A Struct that tries to store 8 true/false values in a single byte.
    /// </summary>
    public struct IntTightBool
    {
        private int storage;

        /// <summary>
        /// Constructor with preset values.
        /// </summary>
        /// <param name="val0">First value.</param>
        /// <param name="val1">Second value.</param>
        /// <param name="val2">Third value.</param>
        /// <param name="val3">Fourth value.</param>
        /// <param name="val4">Fifth value.</param>
        /// <param name="val5">Sixth value.</param>
        /// <param name="val6">Seventh value.</param>
        /// <param name="val7">Eighth value.</param>
        public IntTightBool(bool val0 = false, bool val1 = false,
            bool val2 = false, bool val3 = false, 
            bool val4 = false, bool val5 = false, 
            bool val6 = false, bool val7 = false)
        {
            storage = 0;

            if (val0)
                this[0] = true;
            if (val1)
                this[1] = true;
            if (val2)
                this[2] = true;
            if (val3)
                this[3] = true;
            if (val4)
                this[4] = true;
            if (val5)
                this[5] = true;
            if (val6)
                this[6] = true;
            if (val7)
                this[7] = true;
        }

        /// <summary>
        /// Creates a TightBool with preset storage.
        /// </summary>
        /// <param name="other">Preset storage.</param>
        public IntTightBool(int other)
        {
            this.storage = other;
        }

        /// <summary>
        /// Gets a value from this TightBool
        /// </summary>
        /// <param name="index">index to get value for.</param>
        /// <returns>Boolean value.</returns>
        public bool this[int index]
        {
            // Simple bit check
            get => (storage & (1 << index)) != 0;
            set
            {
                // Make bit mask
                int mask = 1 << index;
                // Disable/Enable bit based on bit mask and value of setter
                storage = value? storage | mask : storage & (~mask);
            }
        }

        /// <summary>
        /// Sets the current storage.
        /// </summary>
        /// <param name="storage">New storage.</param>
        public void SetStorage(int storage) => this.storage = storage;

        /// <summary>
        /// Gets the current storage.
        /// </summary>
        /// <returns>Current storage.</returns>
        public int GetStorage() => this.storage;

        /// <summary>
        /// Gets a value at an index.
        /// </summary>
        /// <param name="index">Index to get value for.</param>
        /// <returns>The value at the given index.</returns>
        public bool GetValue(int index) => this[index];

        /// <summary>
        /// Sets a value at an index.
        /// </summary>
        /// <param name="value">Value to set.</param>
        /// <param name="index">Index to set value for.</param>
        public void SetValue(bool value, int index) => this[index] = value;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < 32; i++)
            {
                sb.Append($"{i}:{this[i]} ");
            }

            return sb.ToString().Trim();
        }

        public override bool Equals(object obj)
        {
            // Equals should compare based on the underlying storage byte.
            return obj.Equals(storage);
        }
    }
}