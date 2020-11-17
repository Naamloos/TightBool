using System;
using System.Collections.Generic;
using System.Text;

namespace Naamloos
{
    /// <summary>
    /// A Struct that tries to store 8 true/false values in a single byte.
    /// </summary>
    public struct TightBool
    {
        private byte storage;

        /// <summary>
        /// Makes a new TightBool with preset values.
        /// </summary>
        /// <param name="trueindices">Indices for values that should be true.</param>
        public TightBool(params int[] trueindices)
        {
            this.storage = 0;

            foreach (var val in trueindices)
            {
                this[val] = true;
            }
        }

        /// <summary>
        /// Creates a TightBool with preset storage.
        /// </summary>
        /// <param name="other">Preset storage.</param>
        public TightBool(byte other)
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
                byte mask = (byte)(1 << index);
                // Disable/Enable bit based on bit mask and value of setter
                storage = (byte)(value? (storage | mask) : (storage & (~mask)));
            }
        }

        /// <summary>
        /// Sets the current storage.
        /// </summary>
        /// <param name="storage">New storage.</param>
        public void SetStorage(byte storage) => this.storage = storage;

        /// <summary>
        /// Gets the current storage.
        /// </summary>
        /// <returns>Current storage.</returns>
        public byte GetStorage() => this.storage;

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

            for (int i = 0; i < 8; i++)
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