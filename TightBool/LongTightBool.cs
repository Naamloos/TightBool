using System;
using System.Collections.Generic;
using System.Text;

namespace Naamloos
{
    /// <summary>
    /// A Struct that tries to store 64 true/false values in a single long.
    /// </summary>
    public struct LongTightBool
    {
        private long storage;

        /// <summary>
        /// Makes a new LongTightBool with preset values.
        /// </summary>
        /// <param name="trueindices">Indices for values that should be true.</param>
        public LongTightBool(params int[] trueindices)
        {
            this.storage = 0;

            foreach (var val in trueindices)
            {
                this[val] = true;
            }
        }

        /// <summary>
        /// Creates a LongTightBool with preset storage.
        /// </summary>
        /// <param name="other">Preset storage.</param>
        public LongTightBool(long other)
        {
            this.storage = other;
        }

        /// <summary>
        /// Gets a value from this LongTightBool
        /// </summary>
        /// <param name="index">index to get value for.</param>
        /// <returns>Boolean value.</returns>
        public bool this[int index]
        {
            // Simple bit check
            get => (storage & ((long)1 << index)) != 0;
            set
            {
                // Make bit mask
                long mask = ((long)1 << index);
                // Disable/Enable bit based on bit mask and value of setter
                storage = (value ? (storage | mask) : (storage & (~mask)));
            }
        }

        /// <summary>
        /// Sets the current storage.
        /// </summary>
        /// <param name="storage">New storage.</param>
        public void SetStorage(long storage) => this.storage = storage;

        /// <summary>
        /// Gets the current storage.
        /// </summary>
        /// <returns>Current storage.</returns>
        public long GetStorage() => this.storage;

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

            for (int i = 0; i < 64; i++)
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
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
    }
}